using AutoMapper;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.DrugOrder;
using HospitalManagement.Services.Dtos.Outgoing.DrugOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public class DrugOrderService : IDrugOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DrugOrderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DrugOrderDto> CreateDrugOrder(string staffIdentificationNumber, DrugOrderRequestDto drugOrder)
        {
            var staff = await _unitOfWork.Staff.GetUserByIdentityNumber(staffIdentificationNumber);

            if (staff == null)
            {
                throw new ArgumentException("Invalid staff id");
            }

            var drug = await _unitOfWork.Drugs.GetDrugByIdentityNumber(drugOrder.DrugIdentificationNumber);

            if (drug == null)
            {
                throw new ArgumentException("Invalid drug identification number");
            }

            if (drug.Quantity < drugOrder.Quantity)
            {
                throw new ArgumentException($"The drug quantity is greater than the available quantity {drug.Quantity} in stock");
            }

            var drugEntity = new DrugOrder
            {
                Drug = drug,
                Staff = staff,
                Quantity = drugOrder.Quantity,
                UnitPrice = drug.Price
            };

            var added = await _unitOfWork.DrugOrders.AddAsync(drugEntity);

            if (added == null)
            {
                throw new ArgumentException("Sorry we are unable to add the drug");
            }

            drug.Quantity = drug.Quantity - added.Quantity;

            var updated = await _unitOfWork.Drugs.UpdateAsync(drug);

            if (updated == null)
            {
                await _unitOfWork.DrugOrders.DeleteAsync(added.Id);
            }

            return _mapper.Map<DrugOrderDto>(added);
        }

        public async Task<bool> DeleteOrder(Guid drugOrderId)
        {
            return await _unitOfWork.DrugOrders.DeleteAsync(drugOrderId);
        }

        public async Task<IEnumerable<DrugOrderDto>> GetAllDrugOrders(int page = 1, int size = 25)
        {
            var order = await _unitOfWork.DrugOrders.GetAllPaginatedAsync(page, size);
            return _mapper.Map<IEnumerable<DrugOrderDto>>(order);
        }
    }
}

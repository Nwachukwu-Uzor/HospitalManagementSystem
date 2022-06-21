using HospitalManagementServices.Dtos.Incoming.DrugOrder;
using HospitalManagementServices.Dtos.Outgoing.DrugOrder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementServices.Contracts
{
    public interface IDrugOrderService
    {
        Task<DrugOrderDto> CreateDrugOrder(string staffIdentificationNumber, DrugOrderRequestDto drugOrder);
        Task<IEnumerable<DrugOrderDto>> GetAllDrugOrders(int page = 1, int size = 25);
        Task<bool> DeleteOrder(Guid drugOrderId);
    }
}

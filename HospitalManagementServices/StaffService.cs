using AutoMapper;
using HospitalManagementDomain.Contracts;
using HospitalManagementServices.Contracts;
using HospitalManagementServices.Dtos.Outgoing.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementServices
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StaffService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StaffRequestDto>> GetAllStaff(int page, int size)
        {
            var staff = await _unitOfWork.Staff.GetAllPaginatedAsync(page, size, new List<string> { "Department" });

            return _mapper.Map<IEnumerable<StaffRequestDto>>(staff);
        }

        public async Task<StaffRequestDto> GetStaffByIdentityNumber(string identityNumber)
        {
            var staff = await _unitOfWork.Staff.GetUserByIdentityNumber(identityNumber);

            if (staff == null)
            {
                throw new ArgumentException("No user matches the identity number provided");
            }

            return _mapper.Map<StaffRequestDto>(staff);
        }

        public async Task<IEnumerable<StaffRequestDto>> SearchForStaffByNameOrEmail(string name = "", string email = "", int page = 1, int size = 25)
        {
            var staff = await _unitOfWork.Staff.SearchForUsers(name, email, page, 25);

            return _mapper.Map<IEnumerable<StaffRequestDto>>(staff);
        }
    }
}

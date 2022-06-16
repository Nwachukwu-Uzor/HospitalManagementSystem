using AutoMapper;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Outgoing.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
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
    }
}

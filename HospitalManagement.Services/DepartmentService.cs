using AutoMapper;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.Departments;
using HospitalManagement.Services.Dtos.Outgoing.Departments;
using HospitalManagement.Services.Dtos.Outgoing.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public class DepartmentService : IDepartmentsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DepartmentRequestDto> CreateDepartment(DepartmentCreationDto departmentDto)
        {
            var dept = _mapper.Map<Department>(departmentDto);

            var departmentToReturn = await _unitOfWork.Departments.CreateAsync(dept);

            return _mapper.Map<DepartmentRequestDto>(departmentToReturn);
        }

        public async Task<IEnumerable<DepartmentRequestDto>> GetAllDepartments(int page, int size)
        {
            var departments = await _unitOfWork.Departments.GetAllPaginatedAsync(page, size);
            return _mapper.Map<IEnumerable<DepartmentRequestDto>>(departments);
        }

        public async Task<DepartmentRequestDto> GetDepartmentByIdentificationNumber(string identificationNumber)
        {
            var dept = await _unitOfWork.Departments.GetDepartmentByNumber(identificationNumber);

            return _mapper.Map<DepartmentRequestDto>(dept);
        }

        public async Task<IEnumerable<StaffRequestDto>> GetStaffForDepartment(string departmentNumber, int page, int size)
        {
            var departments = await _unitOfWork.Staff.GetStaffForDepartment(departmentNumber, page, size);
            return _mapper.Map<IEnumerable<StaffRequestDto>>(departments);
        }
    }
}

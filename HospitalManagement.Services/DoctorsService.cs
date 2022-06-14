using AutoMapper;
using HospitalManagement.BL.Contracts;
using HospitalManagement.Data;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.Doctors;
using HospitalManagement.Services.Dtos.Outgoing.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public class DoctorsService : IDoctorsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DoctorsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DoctorRequestDto>> GetAllDoctorsAsync(int pageNumber = 1, int pageSize = 50)
        {
            var doctors = await _unitOfWork.Doctors.GetAllPaginatedAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<DoctorRequestDto>>(doctors);
        }

        public async Task<DoctorRequestDto> GetDoctorByIdentityNumberAsync(string doctorIdentityNumber)
        {
            var doctor = await _unitOfWork.Doctors.GetUserByIdentityNumber(doctorIdentityNumber);

            if (doctor == null)
            {
                throw new ArgumentException("Invalid doctor identification number");
            }

            return _mapper.Map<DoctorRequestDto>(doctor);
        }

        public async Task<IEnumerable<DoctorRequestDto>> SearchForDoctor(string name = "", string email = "", int page = 1, int size = 25)
        {
            var doctors = await _unitOfWork.Doctors.SearchForUsers(name, email, page, size);
            return _mapper.Map<IEnumerable<DoctorRequestDto>>(doctors);
        }
    }
}

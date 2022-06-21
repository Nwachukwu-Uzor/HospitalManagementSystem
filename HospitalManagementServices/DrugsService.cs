using AutoMapper;
using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using HospitalManagementServices.Contracts;
using HospitalManagementServices.Dtos.Incoming.Drugs;
using HospitalManagementServices.Dtos.Outgoing.Drugs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementServices
{
    public class DrugsService : IDrugsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DrugsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DrugRequestDto> CreateDrug(DrugCreationDto drugCreationDto)
        {
           try
            {
                var drugEntity = _mapper.Map<Drug>(drugCreationDto);

                var drug = await _unitOfWork.Drugs.AddAsync(drugEntity);
                return _mapper.Map<DrugRequestDto>(drug);
            } 
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> DeleteDrug(string drugIdentificationNumber)
        {
            try
            {
                var drug = await _unitOfWork.Drugs.GetDrugByIdentityNumber(drugIdentificationNumber);

                if (drug == null)
                {
                    throw new ArgumentNullException("Unable to find drug with the given identification number");
                }

                return await _unitOfWork.Drugs.DeleteAsync(drug.Id);
            } catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<DrugRequestDto>> GetAllDrugs(int page = 1, int size = 50)
        {
           try
            {
                var drugs = await _unitOfWork.Drugs.GetAllPaginatedAsync(page, size);

                return _mapper.Map<IEnumerable<DrugRequestDto>>(drugs);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<DrugRequestDto> GetDrugByIdentityNumber(string identityNumber)
        {
            try
            {
                var drug = await _unitOfWork.Drugs.GetDrugByIdentityNumber(identityNumber);

                if (drug == null)
                {
                    throw new ArgumentException("No drug found with the identity number provided");
                }

                return _mapper.Map<DrugRequestDto>(drug);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<DrugRequestDto>> SearchForDrugByNameOrDescription(string name = null, string description = null, int page = 1, int size = 50)
        {
            try
            {
                var drugs = await _unitOfWork.Drugs.SearchForDrugByNameOrDescription(name, description, page, size);

                if (drugs == null)
                {
                    throw new ArgumentException("Unable to find drug");
                }
                return _mapper.Map<IEnumerable<DrugRequestDto>>(drugs);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<DrugRequestDto> UpdateDrug(string identityNumber, DrugUpdateDto drugDto)
        {
            try
            {
                var drug = await _unitOfWork.Drugs.GetDrugByIdentityNumber(identityNumber);

                if (drug == null)
                {
                   throw new ArgumentException("No drug found with the identity number provided");
                }
                var updatedDrug = _mapper.Map(drugDto, drug);

                var updatedDrugEntity = await _unitOfWork.Drugs.UpdateAsync(updatedDrug);

                if (updatedDrugEntity == null)
                {
                   throw new ArgumentException("Unable to Update Drug");
                }

                return _mapper.Map<DrugRequestDto>(updatedDrug);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

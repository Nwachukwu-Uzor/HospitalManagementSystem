﻿using HospitalManagement.Services.Dtos.Incoming.Drugs;
using HospitalManagement.Services.Dtos.Outgoing.Drugs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Contracts
{
    public interface IDrugsService
    {
        Task<DrugRequestDto> CreateDrug(DrugCreationDto drugCreationDto);
        Task<IEnumerable<DrugRequestDto>> GetAllDrugs(int page = 1, int size = 50);
        Task<DrugRequestDto> GetDrugByIdentityNumber(string identityNumber);
        Task<DrugRequestDto> UpdateDrug(string identityNumber, DrugUpdateDto drugDto);
        Task<IEnumerable<DrugRequestDto>> SearchForDrugByNameOrDescription(string name = null, string description = null, int page = 1, int size = 50);
        Task<bool> DeleteDrug(string drugIdentificationNumber);
    }
}

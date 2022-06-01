using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Api.Dtos.Responses;
using HospitalManagement.Data;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Data.Entities;
using HospitalManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class DrugsController : BaseController
    {
        public DrugsController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService, ISmsService smsService)
        : base(unitOfWork, mapper, accountService, emailService, smsService)
        {

        }

        [HttpPost]
        public async Task<IActionResult> CreateDrug(DrugCreationDto drugCreationDto) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid drug creation model");
                }

                var drugEntity = _mapper.Map<Drug>(drugCreationDto);

                var drug = await _unitOfWork.Drugs.AddAsync(drugEntity);

                return CreatedAtAction(
                    nameof(GetDrugByIdentityNumber),
                    new { identityNumber = drug.IdentificationNumber },
                    _mapper.Map<DrugRequestDto>(drug)
                );

            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrugs(int page = 1, int size = 50)
        {
            try
            {
                var drugs = await _unitOfWork.Drugs.GetAllPaginatedAsync(page, size);

                return Ok(_mapper.Map<IEnumerable<DrugRequestDto>>(drugs));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("identityNumber", Name = nameof(GetDrugByIdentityNumber))]
        public async Task<IActionResult> GetDrugByIdentityNumber(string identityNumber)
        {
            try
            {
                var drug = await _unitOfWork.Drugs.GetDrugByIdentityNumber(identityNumber);

                if (drug == null)
                {
                    return NotFound("No drug found with the identity number provided");
                }

                return Ok(_mapper.Map<DrugRequestDto>(drug));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Api.Dtos.Responses;
using HospitalManagement.Api.Response;
using HospitalManagement.BL.Contracts;
using HospitalManagement.Data;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<DrugRequestDto>> CreateDrug(DrugCreationDto drugCreationDto) 
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
                    GenerateApiResponse<DrugRequestDto>.GenerateSuccessResponse(_mapper.Map<DrugRequestDto>(drug))
                );

            } catch(Exception ex)
            {
                return BadRequest(GenerateApiResponse<DrugRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrugRequestDto>>> GetAllDrugs(int page = 1, int size = 50)
        {
            try
            {
                var drugs = await _unitOfWork.Drugs.GetAllPaginatedAsync(page, size);

                return Ok(GenerateApiResponse<IEnumerable<DrugRequestDto>>.GenerateSuccessResponse(_mapper.Map<IEnumerable<DrugRequestDto>>(drugs)));
            } catch (Exception ex)
            {
                return BadRequest(GenerateApiResponse<IEnumerable<DrugRequestDto>>.GenerateFailureResponse(ex.Message));
            }
        }

        [HttpGet("{identityNumber}", Name = nameof(GetDrugByIdentityNumber))]
        public async Task<ActionResult<DrugRequestDto>> GetDrugByIdentityNumber(string identityNumber)
        {
            try
            {
                var drug = await _unitOfWork.Drugs.GetDrugByIdentityNumber(identityNumber);

                if (drug == null)
                {
                    return NotFound(GenerateApiResponse<DrugRequestDto>.GenerateFailureResponse("No drug found with the identity number provided"));
                }

                return Ok(GenerateApiResponse<DrugRequestDto>.GenerateSuccessResponse(_mapper.Map<DrugRequestDto>(drug)));
            } catch(Exception ex)
            {
                return BadRequest(GenerateApiResponse<DrugRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }

        [HttpPut("{identityNumber}/update")]
        public async Task<ActionResult<DrugRequestDto>> UpdateDrug(string identityNumber, DrugUpdateDto drugDto)
        {
            try
            {
                var drug = await _unitOfWork.Drugs.GetDrugByIdentityNumber(identityNumber);

                if (drug == null)
                {
                    return NotFound(GenerateApiResponse<DrugRequestDto>.GenerateFailureResponse("No drug found with the identity number provided"));
                }
                var updatedDrug = _mapper.Map(drugDto, drug);

                var updatedDrugEntity = await _unitOfWork.Drugs.UpdateAsync(updatedDrug);

                if(updatedDrugEntity == null)
                {
                    return BadRequest(GenerateApiResponse<DrugRequestDto>.GenerateFailureResponse("Unable to Update Drug"));
                }

                return Ok(GenerateApiResponse<DrugRequestDto>.GenerateSuccessResponse(_mapper.Map<DrugRequestDto>(updatedDrug)));
            }
            catch (Exception ex)
            {
                return BadRequest(GenerateApiResponse<DrugRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<DrugRequestDto>>> SearchForDrugByNameOrDescription(string name=null, string description=null, int page = 1, int size = 50)
        {
            try
            {
                var drugs = await _unitOfWork.Drugs.SearchForDrugByNameOrDescription(name, description, page, size);

                if(drugs == null)
                {
                    return NotFound(GenerateApiResponse<IEnumerable<DrugRequestDto>>.GenerateFailureResponse("Unable to find drug"));
                }
                return Ok(GenerateApiResponse<IEnumerable<DrugRequestDto>>.GenerateSuccessResponse(_mapper.Map<IEnumerable<DrugRequestDto>>(drugs)));
            } catch(Exception ex)
            {
                return BadRequest(GenerateApiResponse<IEnumerable<DrugRequestDto>>.GenerateFailureResponse(ex.Message));
            }
        }
    }
}

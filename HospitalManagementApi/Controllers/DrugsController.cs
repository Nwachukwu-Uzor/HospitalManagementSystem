using HospitalManagement.Api.Response;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.Drugs;
using HospitalManagement.Services.Dtos.Outgoing.Drugs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class DrugsController : BaseController
    {
        private readonly IDrugsService _drugsService;
        public DrugsController(IDrugsService drugsService) : base()
        {
            _drugsService = drugsService;
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

                var drug = await _drugsService.CreateDrug(drugCreationDto);

                return CreatedAtAction(
                    nameof(GetDrugByIdentityNumber),
                    new { identityNumber = drug.IdentificationNumber },
                    GenerateApiResponse<DrugRequestDto>.GenerateSuccessResponse(drug)
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
                var drugs = await _drugsService.GetAllDrugs(page, size);

                return Ok(GenerateApiResponse<IEnumerable<DrugRequestDto>>.GenerateSuccessResponse(drugs));
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
                var drug = await _drugsService.GetDrugByIdentityNumber(identityNumber);

                return Ok(GenerateApiResponse<DrugRequestDto>.GenerateSuccessResponse(drug));
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
                var drug = await _drugsService.UpdateDrug(identityNumber, drugDto);

                return Ok(GenerateApiResponse<DrugRequestDto>.GenerateSuccessResponse(drug));
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
                var drugs = await _drugsService.SearchForDrugByNameOrDescription(name, description, page, size);

                return Ok(GenerateApiResponse<IEnumerable<DrugRequestDto>>.GenerateSuccessResponse(drugs));
            } catch(Exception ex)
            {
                return BadRequest(GenerateApiResponse<IEnumerable<DrugRequestDto>>.GenerateFailureResponse(ex.Message));
            }
        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{drugIdentificationNumber}/delete")]
        public async Task<IActionResult> DeleteDrug(string drugIdentificationNumber)
        {
            try
            {
                var isDeleted = await _drugsService.DeleteDrug(drugIdentificationNumber);

                if (!isDeleted)
                {
                    return BadRequest(GenerateApiResponse<DrugRequestDto>.GenerateFailureResponse("Unable to delete drug"));
                }

                return Ok(GenerateApiResponse<DrugRequestDto>.GenerateEmptySuccessMessage("Drug deleted successfully"));
            } catch(Exception ex)
            {
                return BadRequest(GenerateApiResponse<DrugRequestDto>.GenerateFailureResponse(ex.Message));
            }
        }
    }
}

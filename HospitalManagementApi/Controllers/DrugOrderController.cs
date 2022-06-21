using HospitalManagement.Api.Response;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Dtos.Incoming.DrugOrder;
using HospitalManagement.Services.Dtos.Outgoing.DrugOrder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class DrugOrderController : BaseController
    {
        private IDrugOrderService _drugOrderService;

        public DrugOrderController(IDrugOrderService drugOrderService)
        {
            _drugOrderService = drugOrderService;
        }

        [HttpPost("{staffIdentityNumber}")]
        public async Task<IActionResult> CreateDrugOrder([FromRoute] string staffIdentityNumber, [FromBody] DrugOrderRequestDto drugOrder)
        {
            try
            {
                var drug = await _drugOrderService.CreateDrugOrder(staffIdentityNumber, drugOrder);

                if (drug == null)
                {
                    return BadRequest(GenerateApiResponse<DrugOrderDto>.GenerateFailureResponse("Unable to create drug"));
                }

                return Ok(GenerateApiResponse<DrugOrderDto>.GenerateSuccessResponse(drug));
            } catch(Exception ex)
            {
                return BadRequest(GenerateApiResponse<DrugOrderDto>.GenerateFailureResponse(ex.Message));
            }
        }
    }
}

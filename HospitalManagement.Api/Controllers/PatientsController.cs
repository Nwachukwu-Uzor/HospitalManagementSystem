using AutoMapper;
using HospitalManagement.Data;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Controllers
{
    public class PatientsController : BaseController
    {
        public PatientsController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService)
        : base(unitOfWork, mapper, accountService, emailService)
        { }

        [HttpPost]
        public async Task<IActionResult> CreatePatientAsync()
        {
            try
            {

            } catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}

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
    public class HangfireController : BaseController
    {
        public HangfireController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService, ISmsService smsService)
            : base(unitOfWork, mapper, accountService, emailService, smsService)
        {

        }

        [HttpPost("/appointmentReminder")]
        public async Task<IActionResult> SendAppointmentReminder()
        {
            var appointments = await _unitOfWork.Appointments.GetAppointmentsForTheNextDay();

            foreach(var appointment in appointments)
            {
                var date = $"Tomorrow at {appointment.AppointmentDate.TimeOfDay}";
                var emailToSend = _emailService.GenerateAppointmentEmail(
                    appointment.Patient.User.Email,
                    appointment.Doctor.User.FirstName,
                    appointment.Doctor.IdentificationNumber,
                    date
                );
            }
            return Ok("Messages delivered");
        }
    }
}

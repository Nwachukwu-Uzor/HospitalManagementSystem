using HospitalManagement.BL.Contracts;
using HospitalManagement.BL.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace HospitalManagement.BL
{
    public class EmailService : IEmailService
    {
        private readonly SendGridApi _sendGridApi;

        public EmailService(IOptions<SendGridApi> options)
        {
            _sendGridApi = options.Value ?? throw new ArgumentException(nameof(SendGridApi));
        }

        public Email CreateAccountRegistrationMail(
            string identificationNumber,
            string email,
            string firstName,
            string lastName,
            string accountType
        )
        {
            return new Email
            {
                Body = $"<h3>YOU HAVE BEEN SUCCESSFULLY REGISTERED AS A {accountType.ToUpper()}</h1>" +
                    $"<p>Your identification number is {identificationNumber}</p>",
                ToEmail = email,
                ToName = $"{firstName} {lastName}",
                Subject = "Account Created"
            };
        }

        public Email GenerateAppointmentEmail(
            string email,
            string doctorName,
            string doctorIdentityNumber,
            string date
        )
        {
            return new Email
            {
                Body = $"<h3>You have an appointment on {date}<h3>" +
                  $"<p>With Dr. {doctorName} (Identity Number: {doctorIdentityNumber})</p>" +
                  $"Date: {date}",
                ToEmail = email,
                ToName = null,
                Subject = "Appointment Scheduled"
            };
        }

        public async Task<bool> SendMail(Email email)
        {
            try
            {
                var client = new SendGridClient(_sendGridApi.ApiKey);
                var from = new EmailAddress(_sendGridApi.FromEmail, _sendGridApi.FromName);
                var to = new EmailAddress(email.ToEmail, email.ToName);
                var msg = MailHelper.CreateSingleEmail(from, to, email.Subject, "To Replace this later", email.Body);
                var response = await client.SendEmailAsync(msg);

                if (!response.IsSuccessStatusCode)
                {
                    throw new ArgumentException($"Unable to send mail { await response.Body.ReadAsStringAsync()}");
                }

                return response.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

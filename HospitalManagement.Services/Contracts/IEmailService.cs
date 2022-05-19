using HospitalManagement.Services.Models;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendMail(Email email);

        Email CreateAccountRegistrationMail(string identificationNumber, string email, string firstName, string lastName, string accountType);
        Email GenerateAppointmentEmail(string email, string doctorName, string doctorIdentityNumber, string date);
    }
}

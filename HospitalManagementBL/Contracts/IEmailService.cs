using HospitalManagementBL.Models;
using System.Threading.Tasks;

namespace HospitalManagementBL.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendMail(Email email);

        Email CreateAccountRegistrationMail(string identificationNumber, string email, string firstName, string lastName, string accountType);
        Email GenerateAppointmentEmail(string email, string doctorName, string doctorIdentityNumber, string date);
    }
}

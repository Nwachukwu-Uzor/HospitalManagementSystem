using HospitalManagement.BL.Models;

namespace HospitalManagement.BL.Contracts
{
    public interface ISmsService
    {
        public string SendSms(SMS message);
    }
}

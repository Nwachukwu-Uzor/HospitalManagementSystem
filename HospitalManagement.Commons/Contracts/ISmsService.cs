using HospitalManagement.Commons.Models;

namespace HospitalManagement.Commons.Contracts
{
    public interface ISmsService
    {
        public string SendSms(SMS message);
    }
}

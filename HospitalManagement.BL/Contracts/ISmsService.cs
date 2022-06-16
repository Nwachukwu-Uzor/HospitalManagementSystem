using HospitalManagement.BL.Models;

namespace HospitalManagement.BL.Contracts
{
    public interface ISmsService
    {
        public void SendSms(SMS message);
    }
}

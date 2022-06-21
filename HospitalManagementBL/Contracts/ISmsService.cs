using HospitalManagementBL.Models;

namespace HospitalManagementBL.Contracts
{
    public interface ISmsService
    {
        public void SendSms(SMS message);
    }
}

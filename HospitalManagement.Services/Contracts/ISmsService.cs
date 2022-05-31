using HospitalManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Contracts
{
    public interface ISmsService
    {
        public string SendSms(SMS message);
    }
}

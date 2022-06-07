using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.Contracts
{
    public interface IIdentityNumberGenerator
    {
        string GenerateIdNumber(string designationInitial, int length = 10);
    }
}

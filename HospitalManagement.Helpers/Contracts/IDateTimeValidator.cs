using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Helpers.Contracts
{
    public interface IDateTimeValidator
    {
        public bool Validate(DateTime date);
    }
}

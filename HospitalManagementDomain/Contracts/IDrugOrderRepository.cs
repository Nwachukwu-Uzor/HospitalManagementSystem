using HospitalManagementDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementDomain.Contracts
{
    public interface IDrugOrderRepository : IGenericRepository<DrugOrder>
    {
    }
}

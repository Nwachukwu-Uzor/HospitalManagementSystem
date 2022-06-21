using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementData.Repositories
{
    public class DrugOrderRepository : GenericRepository<DrugOrder>, IDrugOrderRepository
    {
        public DrugOrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}

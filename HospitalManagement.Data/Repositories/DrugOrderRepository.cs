using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Repositories
{
    public class DrugOrderRepository : GenericRepository<DrugOrder>, IDrugOrderRepository
    {
        public DrugOrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}

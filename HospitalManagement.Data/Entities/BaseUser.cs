using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Entities
{
    public abstract class BaseUser : BaseEntity
    {
        public string IdentificationNumber { get; set; }
        public AppUser User { get; set; }
        public Guid UserId { get; set; }
        
    }
}

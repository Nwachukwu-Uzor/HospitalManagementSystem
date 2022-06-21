using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementDomain.Models
{
    public class RefreshToken : BaseEntity
    {
        [ForeignKey(nameof(AppUser))]
        public string  AppUserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}

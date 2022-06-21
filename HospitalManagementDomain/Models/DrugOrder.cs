using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementDomain.Models
{
    public class DrugOrder : BaseEntity
    {
        [ForeignKey(nameof(Drug))]
        public Guid DrugId { get; set; }
        public Drug Drug { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { 
            get {
                return UnitPrice * Quantity;
            } 
        }
        [ForeignKey(nameof(Staff))]
        public string StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}

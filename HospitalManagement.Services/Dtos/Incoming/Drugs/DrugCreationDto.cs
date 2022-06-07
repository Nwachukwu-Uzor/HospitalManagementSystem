using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Services.Dtos.Incoming.Drugs
{
    public class DrugCreationDto
    {
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [Range(1.0, 1000000000000)]
        public decimal Price { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 5)]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}

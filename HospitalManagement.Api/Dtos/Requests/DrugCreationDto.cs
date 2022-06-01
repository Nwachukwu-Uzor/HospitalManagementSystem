using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Dtos.Requests
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
        public string Quantity { get; set; }
    }
}

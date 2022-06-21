using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementServices.Dtos.Incoming.DrugOrder
{
    public class DrugOrderRequestDto
    {
        [Required]
        [StringLength(14, ErrorMessage = "Drug identification number should be at least 14 characters long", MinimumLength = 14)]
        public string DrugIdentificationNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The drug quantity must be greater than 1")]
        public int Quantity { get; set; }
    }
}

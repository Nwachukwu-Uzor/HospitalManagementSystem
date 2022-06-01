using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Dtos.Responses
{
    public class DrugRequestDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string IdentificationNumber { get; set; }
    }
}

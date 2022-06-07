namespace HospitalManagement.Services.Dtos.Outgoing.Drugs
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

namespace HospitalManagement.Domain.Models
{
    public class Drug : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string IdentificationNumber { get; set; }
    }
}

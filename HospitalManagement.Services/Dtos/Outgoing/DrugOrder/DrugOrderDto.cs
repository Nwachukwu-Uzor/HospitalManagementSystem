namespace HospitalManagement.Services.Dtos.Outgoing.DrugOrder
{
    public class DrugOrderDto
    {
        public string Drug { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string StaffId { get; set; }
        public string StaffName { get; set; }
    }
}

namespace AutoManage.Application.DTOs.Sale
{
    public class SaleOut
    {
        public string? VehicleChassis { get; set; }
        public string? SellerName { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal FinalPrice { get; set; }
    }
}

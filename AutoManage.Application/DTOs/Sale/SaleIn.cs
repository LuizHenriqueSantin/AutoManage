namespace AutoManage.Application.DTOs.Sale
{
    public record SaleIn
    {
        public Guid VehicleId { get; set; }
        public Guid SellerId { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal FinalPrice { get; set; }
    }
}

using AutoManage.Domain.Entities.Base;

namespace AutoManage.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Guid VehicleId { get; private set; }
        public Guid SellerId { get; private set; }
        public DateTime SaleDate { get; private set; }
        public decimal FinalPrice { get; private set; }

        public Vehicle? Vehicle { get; private set; }
        public Seller? Seller { get; private set; }

        protected Sale() { }

        public Sale(Guid vehicleId, Guid sellerId, decimal finalPrice, DateTime saleDate)
        {
            VehicleId = vehicleId;
            SellerId = sellerId;
            FinalPrice = finalPrice;
            SaleDate = saleDate;
        }
    }
}

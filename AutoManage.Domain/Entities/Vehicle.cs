using AutoManage.Domain.Entities.Base;
using AutoManage.Domain.Enums;

namespace AutoManage.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Chassis { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public VehicleColor Color { get; private set; }
        public decimal Price { get; private set; }
        public int Mileage { get; private set; }
        public SystemVersion SystemVersion { get; private set; }
        public Guid OwnerId { get; private set; }

        public Owner? Owner { get; private set; }
        public Sale? Sale { get; private set; }

        protected Vehicle() { }

        public Vehicle(
            string chassis,
            string model,
            int year,
            VehicleColor color,
            decimal price,
            int mileage,
            SystemVersion systemVersion)
        {
            Chassis = chassis;
            Model = model;
            Year = year;
            Color = color;
            Price = price;
            Mileage = mileage;
            SystemVersion = systemVersion;
        }

        public bool CanBeSold()
        {
            return OwnerId == Guid.Empty;
        }

        public void UpdateInfos(int? mileage, decimal? price)
        {
            if (mileage != null)
                Mileage = (int)mileage;

            if (price != null)
                Price = (decimal)price;
        }

        public void SellVehicle(Guid ownerId)
        {
            OwnerId = ownerId;
        }
    }
}

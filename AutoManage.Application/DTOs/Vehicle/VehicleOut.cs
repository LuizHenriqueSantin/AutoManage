using AutoManage.Application.DTOs.Owner;
using AutoManage.Domain.Enums;
using ExpenseControl.Application.Helpers;

namespace AutoManage.Application.DTOs.Vehicle
{
    public class VehicleOut
    {
        public Guid Id { get; set; }
        public string? Chassis { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public VehicleColor Color { get; set; }
        public string ColorName => EnumHelper.GetDisplayName(Color); 
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public SystemVersion SystemVersion { get; set; }
        public string SystemVersionName => EnumHelper.GetDisplayName(SystemVersion);
        public OwnerOut? Owner { get; set; }
    }
}

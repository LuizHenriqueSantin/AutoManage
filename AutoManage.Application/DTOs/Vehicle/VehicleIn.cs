using AutoManage.Domain.Enums;

namespace AutoManage.Application.DTOs.Vehicle
{
    public record VehicleIn
    {
        public string? Chassis { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public VehicleColor? Color { get; set; }
        public decimal? Price { get; set; }
        public int? Mileage { get; set; }
        public SystemVersion? SystemVersion { get; set; }
    }
}

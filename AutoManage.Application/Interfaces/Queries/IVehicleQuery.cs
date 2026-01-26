using AutoManage.Application.DTOs.Vehicle;
using AutoManage.Application.Interfaces.Queries.Base;
using AutoManage.Domain.Entities;
using AutoManage.Domain.Enums;

namespace AutoManage.Application.Interfaces.Queries
{
    public interface IVehicleQuery : IBaseQuery<VehicleOut, VehicleIn, Vehicle>
    {
        Task<List<VehicleOut>> GetBySystemVersion(SystemVersion version);
        Task<VehicleOut?> GetWithOwner(Guid id);
    }
}

using AutoManage.Application.DTOs.Vehicle;
using AutoManage.Application.Interfaces.Commands.Base;
using AutoManage.Domain.Entities;
using AutoManage.Domain.Notifications;

namespace AutoManage.Application.Interfaces.Commands
{
    public interface IVehicleCommand : IBaseCommand<VehicleOut, VehicleIn, Vehicle>
    {
        Task<bool> UpdateByChassis(VehicleIn model);
        Task<(bool Success, DomainNotification? Notification)> UpdateOwner(Guid vehicleId, Guid ownerId);
        Task<(bool Success, DomainNotification? Notification)> RemoveOwner(Guid vehicleId);
    }
}

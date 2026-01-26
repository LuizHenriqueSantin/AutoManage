using AutoManage.Application.DTOs.Vehicle;
using AutoManage.Application.Interfaces.Commands;
using AutoManage.Domain.Entities;
using AutoManage.Domain.Interfaces.Repositories;
using AutoManage.Domain.Interfaces.UnitOfWork;
using AutoManage.Domain.Notifications;

namespace AutoManage.Application.Commands
{
    public class VehicleCommand : IVehicleCommand
    {
        private readonly IVehicleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotificationHandler _notifications;

        public VehicleCommand(IVehicleRepository repository, IUnitOfWork unitOfWork, IDomainNotificationHandler notifications)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _notifications = notifications;
        }

        public async Task<bool> Create(VehicleIn model)
        {
            if (!ValidateCreation(model))
                return false;

            var entity = new Vehicle(model.Chassis, model.Model, model.Year.Value, model.Color.Value, model.Price.Value, model.Mileage.Value, model.SystemVersion.Value);
            _repository.Add(entity);

            return await _unitOfWork.Commit();
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                _notifications.Add(new DomainNotification("Vehicle", "Veículo não encontrado!"));
                return false;
            }

            if (entity.OwnerId == Guid.Empty)
            {
                _notifications.Add(new DomainNotification("Vehicle", "Não é possível remover o veículo pois ele pertence a um proprietário!"));
                return false;
            }

            _repository.Delete(entity);

            return await _unitOfWork.Commit();
        }

        public async Task<bool> Update(Guid id, VehicleIn model)
        {
            if (model == null || (model.Price == null && model.Mileage == null))
            {
                _notifications.Add(new DomainNotification("Vehicle", "Envie as informações do veículo!"));
                return false;
            }

            var entity = await _repository.GetById(id);

            return await FinishUpdate(model, entity);
        }

        public async Task<bool> UpdateByChassis(string chassis, VehicleIn model)
        {
            if (model == null || (model.Price == null && model.Mileage == null))
            {
                _notifications.Add(new DomainNotification("Vehicle", "Envie as informações do veículo!"));
                return false;
            }

            var entity = await _repository.GetByChassis(chassis);

            return await FinishUpdate(model, entity);
        }

        public async Task<bool> FinishUpdate(VehicleIn model, Vehicle? entity)
        {
            if (entity == null)
            {
                _notifications.Add(new DomainNotification("Vehicle", "Veículo não encontrado!"));
                return false;
            }

            entity.UpdateInfos(model.Mileage, model.Price);
            _repository.Update(entity);

            return await _unitOfWork.Commit();
        }

        public async Task<(bool Success, DomainNotification? Notification)> UpdateOwner(Guid vehicleId, Guid ownerId)
        {
            var entity = await _repository.GetById(vehicleId);

            if (entity is null)
                return (false, new DomainNotification("Vehicle", "Veículo não encontrado!"));

            if (!entity.CanBeSold())
                return (false, new DomainNotification("Vehicle", "Veículo já vendido!"));

            entity.SellVehicle(ownerId);
            _repository.Update(entity);

            return (true, null);
        }

        private bool ValidateCreation(VehicleIn model)
        {
            if (model == null)
            {
                _notifications.Add(new DomainNotification("Vehicle", "Envie as informações do veículo!"));
                return false;
            }

            if (string.IsNullOrEmpty(model.Chassis))
                _notifications.Add(new DomainNotification("Chassis", "Chassi é obrigatório!"));

            if (string.IsNullOrEmpty(model.Model))
                _notifications.Add(new DomainNotification("Model", "Modelo é obrigatório!"));

            if (model.Year == null || model.Year < 1000)
                _notifications.Add(new DomainNotification("Year", "Ano é obrigatório!"));

            if (!model.Color.HasValue)
                _notifications.Add(new DomainNotification("Color", "Cor é obrigatória!"));

            if (model.Price == null || model.Price == 0)
                _notifications.Add(new DomainNotification("Price", "Preço é obrigatório!"));

            if (model.Mileage == null || model.Mileage < 0)
                _notifications.Add(new DomainNotification("Mileage", "Quilometragem é obrigatória!"));

            if (model.SystemVersion.HasValue)
                _notifications.Add(new DomainNotification("SystemVersion", "Versão do sistema é obrigatória!"));

            if (_notifications.HasNotifications())
                return false;

            return true;
        }
    }
}

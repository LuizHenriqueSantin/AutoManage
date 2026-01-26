using AutoManage.Application.DTOs.Sale;
using AutoManage.Application.Interfaces.Commands;
using AutoManage.Domain.Entities;
using AutoManage.Domain.Interfaces.Repositories;
using AutoManage.Domain.Interfaces.UnitOfWork;
using AutoManage.Domain.Notifications;

namespace AutoManage.Application.Commands
{
    public class SaleCommand : ISaleCommand
    {
        private readonly ISaleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotificationHandler _notifications;
        private readonly IVehicleCommand _vehicleCommand;

        public SaleCommand(ISaleRepository repository, IUnitOfWork unitOfWork, IDomainNotificationHandler notifications, IVehicleCommand vehicleCommand)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _notifications = notifications;
            _vehicleCommand = vehicleCommand;
        }

        public async Task<bool> Create(SaleIn model)
        {
            if(!ValidateCreation(model))
                return false;

            var (success, notification) = await _vehicleCommand.UpdateOwner(model.VehicleId, model.OwnerId);

            if (!success && notification != null)
            {
                _notifications.Add(notification);
                return false;
            }

            var entity = new Sale(model.SellerId, model.VehicleId, model.FinalPrice, model.SaleDate);
            _repository.Add(entity);

            return await _unitOfWork.Commit();
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                _notifications.Add(new DomainNotification("Sale", "Venda não encontrada!"));
                return false;
            }

            _repository.Delete(entity);

            return await _unitOfWork.Commit();
        }

        public Task<bool> Update(Guid id, SaleIn model)
        {
            _notifications.Add(new DomainNotification("Sale", "Vendas são imutáveis após o registro!"));
            return Task.FromResult(false);
        }

        private bool ValidateCreation(SaleIn model)
        {
            if (model == null)
            {
                _notifications.Add(new DomainNotification("Sale", "Envie as informações da venda!"));
                return false;
            }

            if (model.SellerId == Guid.Empty)
                _notifications.Add(new DomainNotification("SellerId", "Vendedor é obrigatório!"));

            if (model.VehicleId == Guid.Empty)
                _notifications.Add(new DomainNotification("VehicleId", "Veículo é obrigatório!"));

            if (model.OwnerId == Guid.Empty)
                _notifications.Add(new DomainNotification("OwnerId", "Proprietário é obrigatório!"));

            if (model.SaleDate >= DateTime.Now)
                _notifications.Add(new DomainNotification("SaleDate", "Data da venda não pode ser futura!"));

            if (model.FinalPrice <= 0)
                _notifications.Add(new DomainNotification("FinalPrice", "Valor da venda inválido!"));

            if (_notifications.HasNotifications())
                return false;

            return true;
        }
    }
}

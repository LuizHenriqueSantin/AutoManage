using AutoManage.Application.DTOs.Owner;
using AutoManage.Application.Interfaces.Commands;
using AutoManage.Domain.Entities;
using AutoManage.Domain.Interfaces.Repositories;
using AutoManage.Domain.Interfaces.UnitOfWork;
using AutoManage.Domain.Notifications;

namespace AutoManage.Application.Commands
{
    public class OwnerCommand : IOwnerCommand
    {
        private readonly IOwnerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotificationHandler _notifications;

        public OwnerCommand(IOwnerRepository repository, IUnitOfWork unitOfWork, IDomainNotificationHandler notifications)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _notifications = notifications;
        }

        public async Task<bool> Create(OwnerIn model)
        {
            var isValid = await ValidateCreation(model);

            if(!isValid)
                return false;

            var entity = new Owner(model.Name, model.Address);

            (bool cpfCnpjSuccess, string cpfCnpjMessage) = entity.SetCpfCnpj(model.CpfCnpj);
            (bool emailSuccess, string emailMessage) = entity.SetEmail(model.Email);
            (bool phoneSuccess, string phoneMessage) = entity.SetPhoneNumber(model.PhoneNumber);

            if(!ValidateValueObjects((cpfCnpjSuccess, cpfCnpjMessage), (emailSuccess, emailMessage), (phoneSuccess, phoneMessage)))
                return false;

            _repository.Add(entity);

            return await _unitOfWork.Commit();
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repository.GetWithVehicles(id);

            if (entity == null)
            {
                _notifications.Add(new DomainNotification("Owner", "Proprietário não encontrado!"));
                return false;
            }

            if(entity.Vehicles != null && entity.Vehicles.Any())
            {
                _notifications.Add(new DomainNotification("Owner", "Não é possível remover o proprietário pois ele possui veículos vinculados!"));
                return false;
            }

            _repository.Delete(entity);

            return await _unitOfWork.Commit();
        }

        public async Task<bool> Update(Guid id, OwnerIn model)
        {
            if (model == null)
            {
                _notifications.Add(new DomainNotification("Owner", "Envie as informações do proprietário!"));
                return false;
            }

            var entity = await _repository.GetById(id);

            if(entity == null)
            {
                _notifications.Add(new DomainNotification("Owner", "Proprietário não encontrado!"));
                return false;
            }

            (bool emailSuccess, string emailMessage) = entity.SetEmail(model.Email);
            (bool phoneSuccess, string phoneMessage) = entity.SetPhoneNumber(model.PhoneNumber);

            if (!ValidateValueObjects((false, string.Empty), (emailSuccess, emailMessage), (phoneSuccess, phoneMessage)))
                return false;

            entity.UpdateContactInfo(model.Address);
            _repository.Update(entity);

            return await _unitOfWork.Commit();
        }

        private async Task<bool> ValidateCreation(OwnerIn model)
        {
            if (model == null)
            {
                _notifications.Add(new DomainNotification("Owner", "Envie as informações do proprietário!"));
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.Name))
                _notifications.Add(new DomainNotification("Name", "Nome é obrigatório!"));

            if (string.IsNullOrWhiteSpace(model.CpfCnpj))
                _notifications.Add(new DomainNotification("CpfCnpj", "Cpf/Cnpj é obrigatório!"));

            if (string.IsNullOrWhiteSpace(model.Address))
                _notifications.Add(new DomainNotification("Address", "Endereço é obrigatório!"));

            if (string.IsNullOrWhiteSpace(model.Email))
                _notifications.Add(new DomainNotification("Email", "Email é obrigatório!"));

            if (string.IsNullOrWhiteSpace(model.PhoneNumber))
                _notifications.Add(new DomainNotification("PhoneNumber", "Telefone é obrigatório!"));

            if (!string.IsNullOrEmpty(model.CpfCnpj))
            {
                var isDuplicate = await _repository.GetByCpfCnpj(model.CpfCnpj) != null;
                if (isDuplicate)
                {
                    _notifications.Add(new DomainNotification("CpfCnpj", "Proprietário ja cadastrado para esse CPF/CNPJ!"));
                }
            }

            if (_notifications.HasNotifications())
                return false;

            return true;
        }

        private bool ValidateValueObjects((bool Success, string Message) cpfCnpj, (bool Success, string Message) email, (bool Success, string Message) phone)
        {
            if (!cpfCnpj.Success && cpfCnpj.Message != string.Empty)
                _notifications.Add(new DomainNotification("CpfCnpj", cpfCnpj.Message));

            if (!email.Success && email.Message != string.Empty)
                _notifications.Add(new DomainNotification("Email", email.Message));

            if (!phone.Success && phone.Message != string.Empty)
                _notifications.Add(new DomainNotification("PhoneNumber", phone.Message));

            if (_notifications.HasNotifications())
                return false;

            return true;
        }
    }
}

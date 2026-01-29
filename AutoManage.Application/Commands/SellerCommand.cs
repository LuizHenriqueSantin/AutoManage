using AutoManage.Application.DTOs.Seller;
using AutoManage.Application.Interfaces.Commands;
using AutoManage.Domain.Entities;
using AutoManage.Domain.Interfaces.Repositories;
using AutoManage.Domain.Interfaces.UnitOfWork;
using AutoManage.Domain.Notifications;

namespace AutoManage.Application.Commands
{
    public class SellerCommand : ISellerCommand
    {
        private readonly ISellerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotificationHandler _notifications;

        public SellerCommand(ISellerRepository repository, IUnitOfWork unitOfWork, IDomainNotificationHandler notifications)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _notifications = notifications;
        }

        public async Task<bool> Create(SellerIn model)
        {
            if (!ValidateCreation(model))
                return false;

            var entity = new Seller(model.Name, (decimal)model.BaseSalary);
            _repository.Add(entity);

            return await _unitOfWork.Commit();
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repository.GetWithSales(id);

            if (entity == null)
            {
                _notifications.Add(new DomainNotification("Seller", "Vendedor não encontrado!"));
                return false;
            }

            if (entity.Sales != null && entity.Sales.Any())
            {
                _notifications.Add(new DomainNotification("Seller", "Não é possível remover o vendedor pois ele possui vendas vinculadas!"));
                return false;
            }

            _repository.Delete(entity);

            return await _unitOfWork.Commit();
        }

        public async Task<bool> Update(Guid id, SellerIn model)
        {
            if (model.BaseSalary == null)
            {
                _notifications.Add(new DomainNotification("BaseSalary", "Envie o novo salário do vendedor!"));
                return false;
            }

            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                _notifications.Add(new DomainNotification("Seller", "Vendedor não encontrado!"));
                return false;
            }

            if (!entity.UpdateBaseSalary((decimal)model.BaseSalary))
            {
                _notifications.Add(new DomainNotification("BaseSalary", "O novo salário não pode ser menor que o anterior!"));
                return false;
            }

            _repository.Update(entity);

            return await _unitOfWork.Commit();
        }

        public async Task<bool> UpdateSellerOfTheMonth()
        {
            var today = DateTime.Now;

            int year = today.Year;
            int month = today.Month;

            var newBestSeller = await _repository.GetTopSeller(year, month);

            if (newBestSeller == null)
            {
                _notifications.Add(new DomainNotification("Seller", "Vendedor não encontrado!"));
                return false;
            }

            if (newBestSeller.IsSellerOfTheMonth) return true;

            var lastBestSeller = await _repository.GetLastTopSeller();

            if (lastBestSeller != null)
            {
                lastBestSeller.RemoveSellerOfTheMonth();
                _repository.Update(lastBestSeller);
            }

            newBestSeller.PromoteToSellerOfTheMonth();
            _repository.Update(newBestSeller);

            return await _unitOfWork.Commit();
        }

        private bool ValidateCreation(SellerIn model)
        {
            if (model == null)
            {
                _notifications.Add(new DomainNotification("Seller", "Envie as informações do vendedor!"));
                return false;
            }

            if (string.IsNullOrEmpty(model.Name))
                _notifications.Add(new DomainNotification("Name", "Nome é obrigatório!"));

            if (model.BaseSalary == null)
                _notifications.Add(new DomainNotification("BaseSalary", "Salário base é obrigatório!"));

            if (_notifications.HasNotifications())
                return false;

            return true;
        }
    }
}

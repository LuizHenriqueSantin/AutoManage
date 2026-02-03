using AutoManage.Application.DTOs.Seller;
using AutoManage.Application.Interfaces.Queries;
using AutoManage.Domain.Interfaces.Repositories;

namespace AutoManage.Application.Queries
{
    public class SellerQuery : ISellerQuery
    {
        private readonly ISellerRepository _repository;

        public SellerQuery(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SellerOut>> GetAll()
        {
            var list = await _repository.GetAll();

            return list.Select(x => new SellerOut
                {
                    Id = x.Id,
                    Name = x.Name,
                    BaseSalary = x.BaseSalary,
                }).ToList();
        }

        public async Task<SellerOut?> GetSellerWithTotalSalary(Guid id)
        {
            var today = DateTime.Now;

            int year = today.Year;
            int month = today.Month;

            var entity = await _repository.GetWithMensalSalesToRead(id, year, month);

            if (entity == null) return null;

            var comissionRate = entity.IsSellerOfTheMonth ? 1.5m/100m : 1m/100m;
            var comissionValue = entity.Sales != null && entity.Sales.Count > 0 ? entity.Sales.Sum(x => x.FinalPrice) * comissionRate : 0;

            var result = new SellerOut
            {
                Name = entity.Name,
                BaseSalary = entity.BaseSalary,
                TotalSalary = entity.BaseSalary + comissionValue,
            };

            return result;
        }
    }
}

using AutoManage.Application.DTOs.Sale;
using AutoManage.Application.Interfaces.Queries;
using AutoManage.Domain.Interfaces.Repositories;

namespace AutoManage.Application.Queries
{
    public class SaleQuery : ISaleQuery
    {
        private readonly ISaleRepository _repository;

        public SaleQuery(ISaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SaleOut>> GetAll()
        {
            var list = await _repository.GetAll();

            return list.Select(x => new SaleOut
                {
                    VehicleChassis = x.Vehicle?.Chassis,
                    SellerName = x.Seller?.Name,
                    SaleDate = x.SaleDate,
                    FinalPrice = x.FinalPrice,
                }).ToList();
        }

        public async Task<List<SaleOut>> GetBySeller(Guid sellerId, int? year, int? month)
        {
            var today = DateTime.Now;

            year ??= today.Year;
            month ??= today.Month;

            var entity = await _repository.GetBySeller(sellerId, year.Value, month.Value);

            if (entity == null) return [];

            var result = entity.Select(x => new SaleOut
            {
                VehicleChassis = x.Vehicle?.Chassis,
                SellerName = x.Seller?.Name,
                SaleDate = x.SaleDate,
                FinalPrice = x.FinalPrice,
            }).ToList();

            return result;
        }
    }
}

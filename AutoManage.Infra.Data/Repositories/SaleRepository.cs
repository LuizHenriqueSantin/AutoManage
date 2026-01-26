using AutoManage.Domain.Entities;
using AutoManage.Domain.Interfaces.Repositories;
using AutoManage.Infra.Data.Context;
using AutoManage.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoManage.Infra.Data.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(AutoManageContext context) : base(context) { }

        public async Task<IList<Sale>> GetBySeller(Guid sellerId, int year, int month)
        {
            try
            {
                return await _context.Sales
                    .AsNoTracking()
                    .Where(x =>
                        x.SellerId == sellerId &&
                        x.SaleDate.Month == month &&
                        x.SaleDate.Year == year)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar vendas do vendedor!", ex);
            }
        }
    }
}

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
                return await _context.Sales
                    .AsNoTracking()
                    .Include(x => x.Vehicle)
                    .Include(x => x.Seller)
                    .Where(x =>
                        x.SellerId == sellerId &&
                        x.SaleDate.Month == month &&
                        x.SaleDate.Year == year)
                    .ToListAsync();
        }
    }
}

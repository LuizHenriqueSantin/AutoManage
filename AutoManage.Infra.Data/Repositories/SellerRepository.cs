using AutoManage.Domain.Entities;
using AutoManage.Domain.Interfaces.Repositories;
using AutoManage.Infra.Data.Context;
using AutoManage.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoManage.Infra.Data.Repositories
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(AutoManageContext context) : base(context) { }

        public async Task<Seller?> GetTopSeller(int year, int month)
        {
                var query = await _context.Sellers
                    .Select(x => new
                    {
                        Seller = x,
                        TotalSales = x.Sales
                            .Where(y => y.SaleDate.Year == year && y.SaleDate.Month == month)
                            .Sum(y => y.FinalPrice)
                    })
                    .OrderByDescending(x => x.TotalSales)
                    .ThenBy(x => x.Seller.Name)
                    .FirstOrDefaultAsync();

                return query?.Seller;
        }
        public async Task<Seller?> GetLastTopSeller()
        {
                return await _context.Sellers.FirstOrDefaultAsync(x => x.IsSellerOfTheMonth);
        }

        public async Task<Seller?> GetWithSales(Guid id)
        {
                return await _context.Sellers.Include(x => x.Sales).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Seller?> GetWithMensalSalesToRead(Guid id, int year, int month)
        {
                return await _context.Sellers
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .Include(x => x.Sales
                        .Where(s => s.SaleDate.Year == year && s.SaleDate.Month == month))
                    .FirstOrDefaultAsync();
        }
    }
}

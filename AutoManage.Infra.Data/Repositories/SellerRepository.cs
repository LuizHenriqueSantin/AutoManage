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
            try
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
                    .FirstOrDefaultAsync();

                return query?.Seller;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encontrar próximo vendedor do mês!", ex);
            }
        }
        public async Task<Seller?> GetLastTopSeller()
        {
            try
            {
                return await _context.Sellers.FirstOrDefaultAsync(x => x.IsSellerOfTheMonth);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encontrar atual vendedor do mês!", ex);
            }
        }

        public async Task<Seller?> GetWithSales(Guid id)
        {
            try
            {
                return await _context.Sellers.Include(x => x.Sales).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar vendedor e vendas!", ex);
            }
        }

        public async Task<Seller?> GetWithMensalSalesToRead(Guid id, int year, int month)
        {
            try
            {
                return await _context.Sellers
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .Include(x => x.Sales
                        .Where(s => s.SaleDate.Year == year && s.SaleDate.Month == month))
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar vendas do mês!", ex);
            }
        }
    }
}

using AutoManage.Domain.Entities;
using AutoManage.Domain.Interfaces.Repositories.Base;

namespace AutoManage.Domain.Interfaces.Repositories
{
    public interface ISellerRepository : IBaseRepository<Seller>
    {
        Task<Seller?> GetTopSeller(int year, int month);
        Task<Seller?> GetLastTopSeller();
        Task<Seller?> GetWithSales(Guid id);
        Task<Seller?> GetWithMensalSalesToRead(Guid id, int year, int month);
    }
}

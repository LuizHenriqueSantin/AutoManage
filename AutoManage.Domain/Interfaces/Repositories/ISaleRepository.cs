using AutoManage.Domain.Entities;
using AutoManage.Domain.Interfaces.Repositories.Base;

namespace AutoManage.Domain.Interfaces.Repositories
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Task<IList<Sale>> GetBySeller(Guid sellerId, int month, int year);
    }
}

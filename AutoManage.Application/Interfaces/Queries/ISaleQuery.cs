using AutoManage.Application.DTOs.Sale;
using AutoManage.Application.Interfaces.Queries.Base;
using AutoManage.Domain.Entities;

namespace AutoManage.Application.Interfaces.Queries
{
    public interface ISaleQuery : IBaseQuery<SaleOut, SaleIn, Sale>
    {
        Task<List<SaleOut>> GetBySeller(Guid sellerId, int? year, int? month);
    }
}

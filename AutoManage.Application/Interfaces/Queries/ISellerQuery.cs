using AutoManage.Application.DTOs.Seller;
using AutoManage.Application.Interfaces.Queries.Base;
using AutoManage.Domain.Entities;

namespace AutoManage.Application.Interfaces.Queries
{
    public interface ISellerQuery : IBaseQuery<SellerOut, SellerIn, Seller>
    {
        Task<SellerOut?> GetSellerWithTotalSalary(Guid id, int? year, int? month);
    }
}

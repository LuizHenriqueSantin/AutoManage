using AutoManage.Application.DTOs.Seller;
using AutoManage.Application.Interfaces.Commands.Base;
using AutoManage.Domain.Entities;

namespace AutoManage.Application.Interfaces.Commands
{
    public interface ISellerCommand : IBaseCommand<SellerOut, SellerIn, Sale>
    {
        Task<bool> UpdateSellerOfTheMonth();
    }
}

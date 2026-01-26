using AutoManage.Application.DTOs.Sale;
using AutoManage.Application.Interfaces.Commands.Base;
using AutoManage.Domain.Entities;

namespace AutoManage.Application.Interfaces.Commands
{
    public interface ISaleCommand : IBaseCommand<SaleOut, SaleIn, Sale>
    {
    }
}

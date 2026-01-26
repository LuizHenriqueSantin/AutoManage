using AutoManage.Application.DTOs.Owner;
using AutoManage.Application.Interfaces.Commands.Base;
using AutoManage.Domain.Entities;

namespace AutoManage.Application.Interfaces.Commands
{
    public interface IOwnerCommand : IBaseCommand<OwnerOut, OwnerIn, Owner>
    {
    }
}

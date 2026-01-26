using AutoManage.Application.DTOs.Owner;
using AutoManage.Application.Interfaces.Queries.Base;
using AutoManage.Domain.Entities;

namespace AutoManage.Application.Interfaces.Queries
{
    public interface IOwnerQuery : IBaseQuery<OwnerOut, OwnerIn, Owner>
    {
        Task<OwnerOut?> GetByCpfCnpj(string cpfCnpj);
    }
}

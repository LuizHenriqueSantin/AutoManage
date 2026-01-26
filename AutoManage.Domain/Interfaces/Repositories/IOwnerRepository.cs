using AutoManage.Domain.Entities;
using AutoManage.Domain.Interfaces.Repositories.Base;

namespace AutoManage.Domain.Interfaces.Repositories
{
    public interface IOwnerRepository : IBaseRepository<Owner>
    {
        Task<Owner?> GetByCpfCnpj(string cpfCnpj);
        Task<Owner?> GetWithVehicles(Guid id);
    }
}

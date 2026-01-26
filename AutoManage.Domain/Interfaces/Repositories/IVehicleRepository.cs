using AutoManage.Domain.Entities;
using AutoManage.Domain.Enums;
using AutoManage.Domain.Interfaces.Repositories.Base;

namespace AutoManage.Domain.Interfaces.Repositories
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        Task<Vehicle?> GetByChassis(string chassis);
        Task<Vehicle?> GetWithOwner(Guid id);
        Task<IList<Vehicle>> GetBySystemVersion(SystemVersion version);
    }
}

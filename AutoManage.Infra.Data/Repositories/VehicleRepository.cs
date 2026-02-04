using AutoManage.Domain.Entities;
using AutoManage.Domain.Enums;
using AutoManage.Domain.Interfaces.Repositories;
using AutoManage.Infra.Data.Context;
using AutoManage.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoManage.Infra.Data.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AutoManageContext context) : base(context) { }

        public async Task<Vehicle?> GetByChassis(string chassis)
        {
                return await _context.Vehicles
                    .FirstOrDefaultAsync(x => x.Chassis == chassis);
        }

        public async Task<Vehicle?> GetWithOwner(Guid id)
        {
                return await _context.Vehicles
                    .AsNoTracking()
                    .Include(x => x.Owner)
                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Vehicle>> GetBySystemVersion(SystemVersion version)
        {
                return await _context.Vehicles
                    .AsNoTracking()
                    .Where(x => x.SystemVersion == version)
                    .ToListAsync();
        }
    }
}

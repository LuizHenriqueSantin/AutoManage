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
            try
            {
                return await _context.Vehicles
                    .FirstOrDefaultAsync(x => x.Chassis == chassis);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar veículo pelo chassi!", ex);
            }
        }

        public async Task<Vehicle?> GetWithOwner(Guid id)
        {
            try
            {
                return await _context.Vehicles
                    .AsNoTracking()
                    .Include(x => x.Owner)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar veículo e vendedor!", ex);
            }
        }

        public async Task<IList<Vehicle>> GetBySystemVersion(SystemVersion version)
        {
            try
            {
                return await _context.Vehicles
                    .AsNoTracking()
                    .Where(x => x.SystemVersion == version)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar veículos pela versão do sistema!", ex);
            }
        }
    }
}

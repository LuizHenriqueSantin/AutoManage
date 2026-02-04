using AutoManage.Domain.Entities;
using AutoManage.Domain.Interfaces.Repositories;
using AutoManage.Domain.ValueObjects;
using AutoManage.Infra.Data.Context;
using AutoManage.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoManage.Infra.Data.Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(AutoManageContext context) : base(context) { }

        public async Task<Owner?> GetByCpfCnpj(string cpfCnpj)
        {
                var normalized = CpfCnpj.Create(cpfCnpj);

                if (!normalized.IsValid)
                    return null;

                return await _context.Owners
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.CpfCnpj.Value == normalized.Value);
        }

        public async Task<Owner?> GetWithVehicles(Guid id)
        {
                return await _context.Owners.Include(x => x.Vehicles).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

using AutoManage.Domain.Interfaces.UnitOfWork;
using AutoManage.Infra.Data.Context;

namespace AutoManage.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoManageContext _context;

        public UnitOfWork(AutoManageContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
                return await _context.SaveChangesAsync() > 0;
        }
    }
}

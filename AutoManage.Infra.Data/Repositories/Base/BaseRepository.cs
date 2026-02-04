using AutoManage.Domain.Interfaces.Repositories.Base;
using AutoManage.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoManage.Infra.Data.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AutoManageContext _context;

        protected BaseRepository(AutoManageContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
                _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
                _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
                _context.Set<T>().Remove(entity);
        }

        public async Task<IList<T>> GetAll()
        {
                return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
                return await _context.Set<T>().FindAsync(id);
        }
    }
}

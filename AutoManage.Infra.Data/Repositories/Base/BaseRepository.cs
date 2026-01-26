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
            try
            {
                _context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar novo item!", ex);
            }
        }
        public void Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar item!", ex);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar item!", ex);
            }
        }

        public async Task<IList<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar dados!", ex);
            }
        }

        public async Task<T?> GetById(Guid id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao bustar dado!", ex);
            }
        }
    }
}

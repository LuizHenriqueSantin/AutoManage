namespace AutoManage.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IList<T>> GetAll();
        Task<T?> GetById(Guid id);
    }
}

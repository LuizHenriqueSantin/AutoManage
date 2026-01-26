namespace AutoManage.Application.Interfaces.Queries.Base
{
    public interface IBaseQuery<OutModel, TModel, TEntity>
    {
        Task<List<OutModel>> GetAll();
    }
}

namespace AutoManage.Application.Interfaces.Commands.Base
{
    public interface IBaseCommand<OutModel, TModel, TEntity>
    {
        Task<bool> Create(TModel model);
        Task<bool> Update(Guid id, TModel model);
        Task<bool> Delete(Guid id);
    }
}

namespace AutoManage.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}

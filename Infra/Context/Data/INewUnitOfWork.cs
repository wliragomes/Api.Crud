namespace Infra.Context.Data
{
    public interface INewUnitOfWork
    {
        Task<bool> Commit();
    }
}

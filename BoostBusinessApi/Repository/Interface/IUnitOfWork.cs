namespace BoostBusinessApi.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        Task Commit();
        void Rollback();
    }
}

namespace BoostBusinessApi.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ISystemErroRepository SystemErroRepository { get; }

        Task Commit();
        void Rollback();
    }
}

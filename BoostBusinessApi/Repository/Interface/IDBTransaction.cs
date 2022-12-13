namespace BoostBusinessApi.Repository.Interface
{
    public interface IDBTransaction : IDisposable
    {
        Task Commit();
        void Rollback();
    }
}

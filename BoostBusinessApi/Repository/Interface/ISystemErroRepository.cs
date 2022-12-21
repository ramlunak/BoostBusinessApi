using BoostBusinessApi.Data.Entity;

namespace BoostBusinessApi.Repository.Interface
{
    public interface ISystemErroRepository
    {
        void Add(SystemErrorEntity entity);
        Task SaveChangesAsync();
    }
}
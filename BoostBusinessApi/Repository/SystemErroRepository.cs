using BoostBusinessApi.Data;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Repository.Interface;

namespace BoostBusinessApi.Repository
{
    public class SystemErroRepository : BaseRepository<SystemErrorEntity>, ISystemErroRepository
    {
        public SystemErroRepository(DBContext context) : base(context)
        {
        }
    }
}

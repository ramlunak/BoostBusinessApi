using BoostBusinessApi.Data;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Repository.Interface;

namespace BoostBusinessApi.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DBContext context) : base(context)
        {
        }
    }
}

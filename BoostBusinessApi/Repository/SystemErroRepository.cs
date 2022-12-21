using BoostBusinessApi.Data;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Repository.Interface;

namespace BoostBusinessApi.Repository
{
    public class SystemErroRepository : ISystemErroRepository
    {
        private readonly DBContext _context;

        public SystemErroRepository(DBContext context)
        {
            this._context = context;
        }

        public void Add(SystemErrorEntity entity)
        {
            _context.Add(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

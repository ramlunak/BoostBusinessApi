using BoostBusinessApi.Data;
using BoostBusinessApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BoostBusinessApi.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DBContext _context;

        public BaseRepository(DBContext context)
        {
            this._context = context;
        }

        public async Task<T> GetByID(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entitties)
        {
            _context.Set<T>().AddRange(entitties);
        }

        public void Delete(int Id)
        {
            var entity = _context.Set<T>().Find(Id);
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entitties)
        {
            _context.Set<T>().RemoveRange(entitties);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}

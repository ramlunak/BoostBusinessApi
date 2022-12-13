using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BoostBusinessApi.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByID(int Id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entitties);
        void Update(T entity);
        void Delete(int Id);
    }
}

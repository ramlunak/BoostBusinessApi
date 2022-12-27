
namespace ConsoleApp1
{
    public class RepositoryBase<T, R> : IRepositoryBase<T, R>
    {
        public RepositoryBase() { }

        public R Post(T enity)
        {
            return default(R);
        }
    }
}

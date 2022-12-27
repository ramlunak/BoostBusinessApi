namespace ConsoleApp1
{
    public interface IRepositoryBase<T,R>
    {
        R Post(T entity);
    }
}
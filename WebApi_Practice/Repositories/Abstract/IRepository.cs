namespace WebApi_Practice.Repositories.Abstract
{
    public interface IRepository<T>
    {

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        IEnumerable<T> GetAll();

        T Get(int id);

    }
}

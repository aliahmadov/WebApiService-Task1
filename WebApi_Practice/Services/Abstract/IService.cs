namespace WebApi_Practice.Services.Abstract
{
    public interface IService<T>
    {

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        T Get(int id);

        IEnumerable<T> GetAll();
    }
}

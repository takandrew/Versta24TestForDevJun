namespace Versta24TestForDevJun.DAL.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<int> GetAllIds();
        T GetById(int id);
    }
}

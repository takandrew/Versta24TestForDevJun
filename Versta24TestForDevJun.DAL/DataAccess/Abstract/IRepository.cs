using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versta24TestForDevJun.DAL.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        IEnumerable<T> GetAll();
    }
}

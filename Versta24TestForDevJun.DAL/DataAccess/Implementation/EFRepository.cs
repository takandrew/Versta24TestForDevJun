using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta24TestForDevJun.DAL.DataAccess.Abstract;
using Versta24TestForDevJun.DAL.DataContext;

namespace Versta24TestForDevJun.DAL.DataAccess.Implementation
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly DeliveryContext _context;
        private readonly DbSet<T> _dbSet;

        public EFRepository(DeliveryContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            _dbSet.Load();
            return _dbSet.AsNoTracking();
        }
    }
}

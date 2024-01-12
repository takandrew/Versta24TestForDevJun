using Microsoft.EntityFrameworkCore;
using Versta24TestForDevJun.DAL.DataAccess.Abstract;
using Versta24TestForDevJun.DAL.DataContext;
using Versta24TestForDevJun.DAL.Entities;

namespace Versta24TestForDevJun.DAL.DataAccess.Implementation
{
    public class OrderRepository : IRepository<Order> 
    {
        private readonly DeliveryContext _context;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(DeliveryContext context)
        {
            _context = context;
            _dbSet = context.Set<Order>();
        }
        public async Task CreateAsync(Order entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Order> GetAll()
        {
            _dbSet.Load();
            return _dbSet.AsNoTracking();
        }

        public IEnumerable<int> GetAllIds()
        {
            return _dbSet.Select(x => x.Id);
        }

        public Order GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
    }
}

using Versta24TestForDevJun.BLL.Models;

namespace Versta24TestForDevJun.BLL.Services.Abstract
{
    public interface IOrderService
    {
        public Task CreateAsync(OrderCreationDTO entity);
        public IEnumerable<Order> GetAll();
        public IEnumerable<int> GetAllIds();
        public Order GetByOrderId(int orderId);
    }
}

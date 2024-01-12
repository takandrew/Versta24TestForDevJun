using Versta24TestForDevJun.BLL.Services.Abstract;
using Versta24TestForDevJun.DAL.DataAccess.Abstract;

namespace Versta24TestForDevJun.BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private IRepository<DAL.Entities.Order> _repository;

        public OrderService(IRepository<DAL.Entities.Order> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Models.Order entity)
        {
            await _repository.CreateAsync(new DAL.Entities.Order
            {
                Id = entity.Id,
                SenderAddress = entity.SenderAddress,
                SenderCity = entity.SenderCity,
                RecipientAddress = entity.RecipientAddress,
                RecipientCity = entity.RecipientCity,
                CargoWeight = entity.CargoWeight,
                CargoPickUpDate = entity.CargoPickUpDate
            });
        }

        public IEnumerable<Models.Order> GetAll()
        {
            IEnumerable<DAL.Entities.Order> orderList = _repository.GetAll();

            var orderDTOList = new List<Models.Order>();
            foreach (var  order in orderList)
            {
                orderDTOList.Add(new Models.Order
                {
                    Id = order.Id,
                    SenderAddress = order.SenderAddress,
                    SenderCity = order.SenderCity, 
                    RecipientAddress = order.RecipientAddress,
                    RecipientCity = order.RecipientCity,
                    CargoWeight = order.CargoWeight,
                    CargoPickUpDate = order.CargoPickUpDate
                });
            }
            return orderDTOList;
        }

        public IEnumerable<int> GetAllIds()
        {
            return _repository.GetAllIds();
        }

        public Models.Order GetByOrderId(int orderId)
        {
            var order = _repository.GetById(orderId);
            return new Models.Order
            {
                Id = order.Id,
                SenderAddress = order.SenderAddress,
                SenderCity = order.SenderCity,
                RecipientAddress = order.RecipientAddress,
                RecipientCity = order.RecipientCity,
                CargoWeight = order.CargoWeight,
                CargoPickUpDate = order.CargoPickUpDate
            };
        }
    }
}

using System.Globalization;
using System.Text.RegularExpressions;
using Versta24TestForDevJun.BLL.Models;
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

        public async Task CreateAsync(OrderCreationDTO entity)
        {
            double cargoWeightDouble;

            if (!double.TryParse(entity.CargoWeight, NumberStyles.Float, CultureInfo.InvariantCulture, out cargoWeightDouble))
            {
                throw new ArgumentException("Не удалось распарсить CargoWeight из string в double.");
            }

            DateOnly cargoPickUpDateDateOnly;

            if (!DateOnly.TryParse(entity.CargoPickUpDate, out cargoPickUpDateDateOnly))
            {
                throw new ArgumentException("Не удалось распарсить CargoPickUpDate из string в DateOnly.");
            }

            await _repository.CreateAsync(new DAL.Entities.Order
            {
                SenderAddress = entity.SenderAddress,
                SenderCity = entity.SenderCity,
                RecipientAddress = entity.RecipientAddress,
                RecipientCity = entity.RecipientCity,
                CargoWeight = cargoWeightDouble,
                CargoPickUpDate = cargoPickUpDateDateOnly
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
            if (order == null)
            {
                return null;
            }
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

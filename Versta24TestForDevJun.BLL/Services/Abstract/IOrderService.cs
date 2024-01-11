using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta24TestForDevJun.BLL.Models;

namespace Versta24TestForDevJun.BLL.Services.Abstract
{
    public interface IOrderService
    {
        public Task CreateAsync(Order entity);
        public IEnumerable<Order> GetAll();
    }
}

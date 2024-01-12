using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Versta24TestForDevJun.BLL.Services.Abstract;
using Versta24TestForDevJun.WEB.Models;

namespace Versta24TestForDevJun.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        
        public IActionResult Index()
        {
            IEnumerable<int> orderList = _orderService.GetAllIds();
            return View(orderList);
        }

        [HttpGet("Home/Index/{id}")]
        public IActionResult Index(int id)
        {
            var order = _orderService.GetByOrderId(id);

            if (order == null)
            {
                return NotFound();
            }

            return new JsonResult(new
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

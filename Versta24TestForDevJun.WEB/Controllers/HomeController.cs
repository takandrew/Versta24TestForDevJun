using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Versta24TestForDevJun.BLL.Models;
using Versta24TestForDevJun.BLL.Services;
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
            IEnumerable<Order> orderList = _orderService.GetAll();
            return View(orderList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

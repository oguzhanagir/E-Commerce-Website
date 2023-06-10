using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SellingProducts()
        {
            var sellingProductsList = _orderService.GetAll();
            return View(sellingProductsList);
        }
    }
}

using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize(Roles = "Admin")]
        public IActionResult ConfirmOrder(int id)
        {
            _orderService.ConfirmOrderService(id);
            return RedirectToAction("SellingProducts","Order");
        }
        
        
        [Authorize(Roles = "Admin")]
        public IActionResult CancelOrder(int id)
        {
            _orderService.CancelOrderService(id);
            return RedirectToAction("SellingProducts", "Order");
        }

        
        [Authorize(Roles = "Admin")]
        public IActionResult SellingProducts()
        {
            var sellingProductsList = _orderService.GetAll();
            
             
            return View(sellingProductsList);
        }
    }
}

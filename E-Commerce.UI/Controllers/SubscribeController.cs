using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce.UI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
                _subscribeService = subscribeService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SubscribeListAdmin()
        {
            var subscribeList = _subscribeService.GetAll();
            return View(subscribeList);
        }

        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            _subscribeService.Create(subscribe);
           return RedirectToAction("Index","Home");
        }

    }
}

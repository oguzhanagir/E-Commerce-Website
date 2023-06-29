using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce.UI.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddCargoByOrder()
        {
            
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCargoByOrder(Cargo cargo)
        {
            _cargoService.Create(cargo);
            return RedirectToAction("SellingProducts","Order");
        }

    }
}

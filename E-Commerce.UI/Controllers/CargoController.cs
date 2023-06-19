using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCargoByOrder()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddCargoByOrder(Cargo cargo)
        {
            _cargoService.Create(cargo);
            return RedirectToAction("SellingProducts","Order");
        }

    }
}

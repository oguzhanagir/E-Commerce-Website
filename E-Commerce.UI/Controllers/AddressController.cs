using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public AddressController(IAddressService addressService,IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddressByUser()
        {
            string email = HttpContext.Session.GetString("Email")!;
            if (!string.IsNullOrEmpty(email))
            {
                var user = _userService.GetUserByMail(email);
                var addressListByUser = _addressService.GetAddressesByUser(user.Id);
                return View(addressListByUser);
            }
            return RedirectToAction("Login", "Auth");
         
        }

        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddAddress(Address address)
        {
            string email = HttpContext.Session.GetString("Email")!;
            if (!string.IsNullOrEmpty(email))
            {
                var user = _userService.GetUserByMail(email);
                address.User!.Id = user.Id;
                _addressService.Create(address);
            }
            return RedirectToAction("AddressByUser","Address");
        }


    }
}

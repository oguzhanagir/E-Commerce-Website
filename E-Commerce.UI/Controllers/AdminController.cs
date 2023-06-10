using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewOrders()
        {
            var totalNewOrders = _adminService.GetNewOrdersStatistics(30);

            ViewBag.TotalNewOrders = totalNewOrders.TotalOrdersCount;
            ViewBag.PercentageChange = totalNewOrders.PercentageChange;
            return View();
        }

        public IActionResult TotalIncome()
        {
            var totalIncomeStatistics = _adminService.GetTotalIncomeStatistics();
            ViewBag.TotalIncomeToday = totalIncomeStatistics.TotalIncomeToday.ToString("C"); // Bugünkü toplam gelir
            ViewBag.TotalIncomeYesterday = totalIncomeStatistics.TotalIncomeYesterday.ToString("C"); // Dünkü toplam gelir
            ViewBag.PercentageChange = totalIncomeStatistics.PercentageChange.ToString("F2"); // Yüzdelik değişim (iki ondalık basamaklı)

            return View();
        }

        public IActionResult NewUsersNumber()
        {
            var totalNewUsers = _adminService.TotalNewUsers();
            ViewBag.TotalNewUsers = totalNewUsers;
            return View();
        }

        public IActionResult TotalExpense()
        {
            var totalExpense = _adminService.GetExpenseStatistics();
            ViewBag.TotalExpense = totalExpense.TotalExpenseToday;
            ViewBag.PercentageChange = totalExpense.PercentageChange;
            return View();
        }

        public IActionResult YearlySalesTotal()
        {
            var yearlySalesTotal = _adminService.CalculateYearlySalesTotal();
            ViewBag.YearlySalesTotal = yearlySalesTotal;
            return View();
        }

        public IActionResult TopSellingProducts()
        {
            var sellingProducts = _adminService.GetTopSellingProducts();
            return View(sellingProducts);
        }

        public IActionResult SalesForecast()
        {
            var salesForecast = _adminService.CalculateSalesForecast(6);
            ViewBag.SalesForecast = salesForecast;
            return View(salesForecast);
        }

        public IActionResult TrafficNumber()
        {
            return View();
        }
    }
}

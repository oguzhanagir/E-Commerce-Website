using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Service
{
    public class AdminService:IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TotalIncomeStatistics GetTotalIncomeStatistics()
        {
            DateTime today = DateTime.Now;
            DateTime yesterday = today.AddDays(-1);

            decimal totalIncomeToday = CalculateTotalIncomeForDate(today);
            decimal totalIncomeYesterday = CalculateTotalIncomeForDate(yesterday);

            decimal percentageChange = 0;
            if (totalIncomeYesterday != 0)
            {
                percentageChange = ((totalIncomeToday - totalIncomeYesterday) / totalIncomeYesterday) * 100;
            }

            var statistics = new TotalIncomeStatistics
            {
                TotalIncomeToday = totalIncomeToday,
                TotalIncomeYesterday = totalIncomeYesterday,
                PercentageChange = percentageChange
            };

            return statistics;
        }

        private decimal CalculateTotalIncomeForDate(DateTime date)
        {
            decimal totalIncomeValue = 0;
            var ordersForDate = _unitOfWork.Orders.GetAll().Where(order => order.CreatedAt.Date == date.Date);

            foreach (var order in ordersForDate)
            {
                totalIncomeValue += order.TotalAmount;
            }

            return totalIncomeValue;
        }




        public decimal TotalExpense()
        {
            decimal totalSales = 0;
            decimal totalExpenses = 0;
            var getAllOrders = _unitOfWork.Orders.GetAll();

            foreach (var order in getAllOrders)
            {
                totalSales += order.TotalAmount;
                decimal orderExpenses = order.TotalAmount * 0.18m + 10m; // 10m 10 TL Kargo ücretini içerir.
                totalExpenses += orderExpenses;
            }

            decimal totalExpense = totalExpenses;
            return totalExpense;
        }

        public ExpenseStatistics GetExpenseStatistics()
        {
            decimal totalExpenseToday = TotalExpense();
            decimal totalExpenseYesterday = 0; // Önceki günün giderleri


            // Önceki günün tarihini bulmak için
            DateTime yesterday = DateTime.Today.AddDays(-1);

            // Önceki günün siparişlerini alıp giderlerini hesapla
            var getYesterdayOrders = _unitOfWork.Orders.GetOrdersByDate(yesterday);
            foreach (var order in getYesterdayOrders)
            {
                decimal orderExpenses = order.TotalAmount * 0.18m + 10m; // 10m 10 TL Kargo ücretini içerir.
                totalExpenseYesterday += orderExpenses;
            }

            decimal percentageChange = 0;
            if (totalExpenseYesterday != 0)
            {
                percentageChange = (totalExpenseToday - totalExpenseYesterday) / totalExpenseYesterday * 100;
            }

            var expenseStatistics = new ExpenseStatistics
            {
                TotalExpenseToday = totalExpenseToday,
                TotalExpenseYesterday = totalExpenseYesterday,
                PercentageChange = percentageChange
            };

            return expenseStatistics;
        }




        public NewOrdersStatistics GetNewOrdersStatistics(int numberOfDays)
        {
            DateTime startDate = DateTime.Now.AddDays(-numberOfDays);
            DateTime endDate = DateTime.Now;

            var totalOrdersCountStart = _unitOfWork.Orders.GetAll().Count(order => order.CreatedAt >= startDate && order.CreatedAt <= endDate.AddDays(-1));
            var totalOrdersCountEnd = _unitOfWork.Orders.GetAll().Count(order => order.CreatedAt >= startDate && order.CreatedAt <= endDate);

            decimal percentageChange = 0;
            if (totalOrdersCountStart != 0)
            {
                percentageChange = ((decimal)(totalOrdersCountEnd - totalOrdersCountStart) / totalOrdersCountStart) * 100;
            }

            var statistics = new NewOrdersStatistics
            {
                TotalOrdersCount = totalOrdersCountEnd,
                PercentageChange = percentageChange
            };

            return statistics;
        }



        public int TotalNewUsers()
        {
            var totalUsers = _unitOfWork.Users.GetAll();

            var countUsers = totalUsers.Count();

            return countUsers;
        }



        public decimal CalculateYearlySalesTotal()
        {
            decimal yearlySalesTotal = 0;
            var getAllOrders = _unitOfWork.Orders.GetAll();

            foreach (var order in getAllOrders)
            {
                yearlySalesTotal += order.TotalAmount;
            }

            return yearlySalesTotal;
        }

        public IEnumerable<Order> GetTopSellingProducts()
        {
            var getAllOrders = _unitOfWork.Orders.GetAll();
        
            return getAllOrders;
        }

        public decimal CalculateSalesForecast(int numberOfMonths)
        {
            var lastMonthsOrders = _unitOfWork.Orders.GetLastMonthsOrders(numberOfMonths);
            decimal totalSales = lastMonthsOrders.Sum(order => order.TotalAmount);

            decimal averageMonthlySales = totalSales / numberOfMonths;
            decimal projectedSales = averageMonthlySales * 12;

            return projectedSales;
        }

     
    }
}

using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Service
{
    public interface IAdminService
    {

        int TotalNewUsers();
        decimal TotalExpense();
        TotalIncomeStatistics GetTotalIncomeStatistics();
        NewOrdersStatistics GetNewOrdersStatistics(int numberOfDays);
        decimal CalculateYearlySalesTotal();
        IEnumerable<Order> GetTopSellingProducts();
        decimal CalculateSalesForecast(int numberOfMonths);
        ExpenseStatistics GetExpenseStatistics();
    }
}

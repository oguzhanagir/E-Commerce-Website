using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class ExpenseStatistics
    {
        public decimal TotalExpenseToday { get; set; }
        public decimal TotalExpenseYesterday { get; set; }
        public decimal PercentageChange { get; set; }
    }
}

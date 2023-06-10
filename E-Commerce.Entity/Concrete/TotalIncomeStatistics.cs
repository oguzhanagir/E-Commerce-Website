using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class TotalIncomeStatistics
    {
        public decimal TotalIncomeToday { get; set; }
        public decimal TotalIncomeYesterday { get; set; }
        public decimal PercentageChange { get; set; }
    }
}

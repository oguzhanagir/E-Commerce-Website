using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly CommerceDbContext _context;
        public OrderRepository(CommerceDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public List<Order> GetLastMonthsOrders(int numberOfMonths)
        {
            DateTime startDate = DateTime.Now.AddMonths(-numberOfMonths);
            DateTime endDate = DateTime.Now;

            var lastMonthsOrders = _context.Orders!
                .Where(order => order.CreatedAt >= startDate && order.CreatedAt <= endDate)
                .ToList();

            return lastMonthsOrders;
        }

        public IEnumerable<Order> GetOrdersByDate(DateTime date)
        {
            return _context.Orders!.Where(order => order.CreatedAt.Date == date.Date).ToList();
        }

        public IEnumerable<Order> GetListByUser(int id)
        {
            var orders = _context.Orders!
        .Include(o => o.OrderItems)
        .Where(o => o.UserId == id)
        .ToList();

            return orders;
        }
    }
}


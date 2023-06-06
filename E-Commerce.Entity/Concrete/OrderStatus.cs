using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class OrderStatus:BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}

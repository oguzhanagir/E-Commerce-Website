using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class OrderItem:BaseEntity
    {
        public ICollection<Product>? Products { get; set; }
        public int Quantity { get; set; }
    }
}

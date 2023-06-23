using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class Product:BaseEntity
    {
        public string? Name { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Features { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<ProductImage>? ProductImages { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}

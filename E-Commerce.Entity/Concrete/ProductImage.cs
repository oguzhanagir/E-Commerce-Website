using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class ProductImage : BaseEntity
    {
        public string? ImagePath { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}

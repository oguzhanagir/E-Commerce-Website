using E_Commerce.Entity.Abstract;
using E_Commerce.Entity.Concrete.ar;
using E_Commerce.Entity.Concrete.en;
using E_Commerce.Entity.Concrete.ru;
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
        public ProductEN? ProductEN { get; set; }
        public ProductAR? ProductAR { get; set; }
        public ProductRU? ProductRU { get; set; }
    }
}

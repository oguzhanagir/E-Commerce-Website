using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete.en
{
    public class SubCategoryEN : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<Product> Product { get; set; }
        public int CategoryId { get; set; }
        public CategoryEN? Category { get; set; }
    }
}

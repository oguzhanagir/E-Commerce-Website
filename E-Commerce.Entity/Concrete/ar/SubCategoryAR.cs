using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete.ar
{
    public class SubCategoryAR : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<Product> Product { get; set; }
        public int CategoryId { get; set; }
        public CategoryAR? Category { get; set; }
    }
}

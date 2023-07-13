using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete.ar
{
    public class CategoryAR : BaseEntity
    {
        public string? Name { get; set; }
        public string? Image { get; set; }

        public ICollection<Product>? Products { get; set; }
        public ICollection<SubCategoryAR>? SubCategories { get; set; }
    }
}

using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class SearchResultViewModel:BaseEntity
    {
        public string? Name { get; set; }
        public string? Image  { get; set; }

        public decimal Price { get; set; }

        public string? SubTitle { get; set; }
    }
}

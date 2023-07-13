using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete.ar
{
    public class BlogAR : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }

        public string? BlogCategory { get; set; }
    }
}

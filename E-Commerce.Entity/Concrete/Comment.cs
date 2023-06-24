using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class Comment : BaseEntity
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? Title { get; set; } 
        public string? Mail { get; set; } 
        public string? Content { get; set; }
        public int Star { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}

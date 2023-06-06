
using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class Address:BaseEntity
    {
        public string? Name { get; set; }
        public string? Line { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Zip { get; set; }
        public User? User { get; set; }
    }
}

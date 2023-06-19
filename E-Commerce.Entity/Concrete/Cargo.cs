using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class Cargo : BaseEntity
    {
        public string? No { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}

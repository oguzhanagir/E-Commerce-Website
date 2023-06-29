using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class Role : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<User>? User { get; set; }
    }
}

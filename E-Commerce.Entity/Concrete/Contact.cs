using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class Contact : BaseEntity
    {
        public string? FullName { get; set; }
        public string? Subject { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }
    }
}

using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class About : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImagePath { get; set; }
        public string? CompanyMail { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyPhoneNumber { get; set; }
    }
}

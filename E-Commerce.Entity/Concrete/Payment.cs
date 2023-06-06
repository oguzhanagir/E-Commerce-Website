using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus? Status { get; set; }
        public PaymentMethod? Method { get; set; }
       
    }

}

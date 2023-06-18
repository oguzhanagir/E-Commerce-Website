using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class Order : BaseEntity
    {
        public string? No { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus? Status { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }

        public int AddressId { get; set; }
        public Address? ShippingAddress { get; set; }

        public int PaymentId { get; set; } 
        public Payment? Payment { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

    }

}

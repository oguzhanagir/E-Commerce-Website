using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Address>? Addresses { get; set; }
        public ICollection<Payment>? Payments { get; set; }

        public int CardId { get; set; }
        public Cart? Cart { get; set; }
    }

}

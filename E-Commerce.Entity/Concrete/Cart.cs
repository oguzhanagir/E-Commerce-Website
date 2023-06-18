using E_Commerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entity.Concrete
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

       
    }
}

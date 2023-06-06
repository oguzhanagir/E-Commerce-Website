using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class PaymentMethodRepository : GenericRepository<PaymentMethod> , IPaymentMethodRepository 
    {
        public PaymentMethodRepository(CommerceDbContext dbContext): base(dbContext)
        {
                
        }
    }
}

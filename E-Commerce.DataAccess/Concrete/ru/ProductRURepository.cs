using E_Commerce.Core.Abstract.Repository.ar;
using E_Commerce.Core.Abstract.Repository.ru;
using E_Commerce.Entity.Concrete.ar;
using E_Commerce.Entity.Concrete.ru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete.ru
{
    public class ProductRURepository : GenericRepository<ProductRU>, IProductRURepository
    {
        public ProductRURepository(CommerceDbContext dbContext) : base(dbContext)
        {

        }
    }
}

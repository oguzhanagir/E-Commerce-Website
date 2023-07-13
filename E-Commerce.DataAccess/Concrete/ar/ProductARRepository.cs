using E_Commerce.Core.Abstract.Repository.ar;
using E_Commerce.Core.Abstract.Repository.en;
using E_Commerce.Entity.Concrete.ar;
using E_Commerce.Entity.Concrete.en;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete.ar
{
    public class ProductARRepository : GenericRepository<ProductAR>, IProductARRepository
    {
        public ProductARRepository(CommerceDbContext dbContext) : base(dbContext)
        {

        }
    }
}

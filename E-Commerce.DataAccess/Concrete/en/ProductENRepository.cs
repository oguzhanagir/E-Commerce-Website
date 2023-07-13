using E_Commerce.Core.Abstract.Repository.en;
using E_Commerce.Entity.Concrete.en;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete.en
{
    public class ProductENRepository : GenericRepository<ProductEN>, IProductENRepository
    {
        public ProductENRepository(CommerceDbContext dbContext) : base(dbContext)
        {

        }
    }
}

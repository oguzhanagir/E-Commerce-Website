using E_Commerce.Core.Abstract.Repository.ru;
using E_Commerce.Entity.Concrete.ru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete.ru
{
    public class CategoryRURepository : GenericRepository<CategoryRU>, ICategoryRURepository
    {
        public CategoryRURepository(CommerceDbContext dbContext) : base(dbContext)
        {

        }
    }
}

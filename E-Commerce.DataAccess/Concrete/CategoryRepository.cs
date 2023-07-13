using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
        private readonly CommerceDbContext _dbContext;
        public CategoryRepository(CommerceDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetLastUsedId()
        {
            var lastUsedId = _dbContext.Categories!
                .OrderByDescending(c => c.Id)
                .Select(c => c.Id)
                .FirstOrDefault();

            return lastUsedId;
        }

    }
}

using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class BlogRepository: GenericRepository<Blog>, IBlogRepository
    {
        private readonly CommerceDbContext _dbContext;
        public BlogRepository(CommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Blog> GetLatestBlogToThree()
        {
            return _dbContext.Blogs!.OrderByDescending(b=>b.CreatedAt).Take(3).ToList();
        }
    }
}

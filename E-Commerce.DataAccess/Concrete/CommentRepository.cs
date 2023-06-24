using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly CommerceDbContext _dbContext;
        public CommentRepository(CommerceDbContext dbContext) : base(dbContext)
        {
                _dbContext = dbContext;
        }


        public List<Comment> GetCommentByProductId(int id)
        {
            var commentByProductId = _dbContext.Comments!.Where(c => c.ProductId == id).ToList();
            return commentByProductId;
        }

    }
}

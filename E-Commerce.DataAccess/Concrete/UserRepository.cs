using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly CommerceDbContext _dbContext;
        public UserRepository(CommerceDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Set<User>().FirstOrDefault(u => u.Email == email)!;
        }

      
    }
}

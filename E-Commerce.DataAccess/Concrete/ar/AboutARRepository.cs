using E_Commerce.Core.Abstract.Repository.ar;
using E_Commerce.Entity.Concrete.ar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete.ar
{
    public class AboutARRepository : GenericRepository<AboutAR>, IAboutARRepository
    {
        public AboutARRepository(CommerceDbContext dbContext) : base(dbContext)
        {

        }
    }
}

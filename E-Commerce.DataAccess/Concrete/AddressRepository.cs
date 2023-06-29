using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class AddressRepository : GenericRepository<Address>,IAddressRepository
    {
        private readonly CommerceDbContext _dbContext;
        public AddressRepository(CommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Address> GetAddressesByUserId(int id)
        {
            var addresses = _dbContext.Addresses!
                .Include(a => a.User)
                .Where(a => a.User!.Id == id)
                .ToList();

            return addresses!;
        }
    }
}

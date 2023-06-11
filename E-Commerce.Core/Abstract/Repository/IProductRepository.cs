using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetPopularProduct();
        IEnumerable<Product> GetBestSellers();
        Task<int> GetCountByCategoryId(int categoryId);
        IEnumerable<Product> GetNewArrivalsToThree();
    }
}

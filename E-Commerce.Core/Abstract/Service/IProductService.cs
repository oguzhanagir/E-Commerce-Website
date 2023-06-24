using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Service
{
    public interface IProductService : IGenericService<Product>
    {
        IEnumerable<Product> GetAllWithCategory();
        IEnumerable<Category> GetCategories();
        IEnumerable<Product> GetPopularProducts();
        IEnumerable<Product> GetBestSellers();
        IEnumerable<Product> GetNewArrivalsToThree();
        IEnumerable<Product> GetAllWithCategoryById(int id);
        int GetPointByProductId(int id);
    }
}

using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Service
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<int> GetProductCountWithCategory(int id);
        IEnumerable<Category> GetAllNormal();
    }
}

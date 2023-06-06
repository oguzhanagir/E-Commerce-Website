using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Service
{
    public interface IGenericService<T>
    {
        T GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

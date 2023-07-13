using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Abstract;
using GTranslate.Translators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CommerceDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public AggregateTranslator Translator { get; set; }
        public GenericRepository(CommerceDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            Translator = new AggregateTranslator();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public T? Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

     
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;


            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();

            
        }




        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id)!;
        }

        public T GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault(x => x.Id == id)!;
        }


        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }

}

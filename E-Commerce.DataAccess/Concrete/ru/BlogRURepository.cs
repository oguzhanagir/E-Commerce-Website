﻿using E_Commerce.Core.Abstract.Repository.ru;
using E_Commerce.Entity.Concrete.ru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete.ru
{
    public class BlogRURepository : GenericRepository<BlogRU>, IBlogRURepository
    {
        public BlogRURepository(CommerceDbContext dbContext) : base(dbContext)
        {

        }
    }
}

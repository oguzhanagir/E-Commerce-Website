﻿using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Service
{
    public interface IBlogService : IGenericService<Blog>
    {
        IEnumerable<Blog> GetAllNormal();
        IEnumerable<Blog> GetLatestBlogToThree();
        IEnumerable<Blog> GetByIdList(int id);
        List<string> GetBlogCategoryList();
    }
}

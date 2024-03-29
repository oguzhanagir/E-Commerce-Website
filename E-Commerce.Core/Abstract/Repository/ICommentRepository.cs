﻿using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Repository
{
    public interface ICommentRepository: IGenericRepository<Comment>
    {
        List<Comment> GetCommentByProductId(int id);
        List<Comment> GetCommentByBlogId(int id);
    }
}

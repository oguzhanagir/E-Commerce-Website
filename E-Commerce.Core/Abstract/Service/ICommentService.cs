﻿using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Service
{
    public interface ICommentService : IGenericService<Comment>
    {
        IEnumerable<Comment> GetCommentsByProductId(int id);
        IEnumerable<Comment> GetCommentListTypeBlog(int id);
    }
}

﻿using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Repository
{
    public interface IAddressRepository:IGenericRepository<Address>
    {
        IEnumerable<Address> GetAddressesByUserId(int id);
    }
}

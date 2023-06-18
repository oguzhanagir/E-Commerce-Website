using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Service
{
    public interface IUserService : IGenericService<User>
    {
        bool Register(User user);
        bool GetCheckEmail(string email);
        bool ValidateUser(string email, string password);
        User GetUserByMail(string mail);

    }
}

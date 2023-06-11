using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(User entity)
        {
            _unitOfWork.Users.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public  void Delete(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user != null)
            {
                 _unitOfWork.Users.Remove(user);
                 _unitOfWork.CompleteAsync();
            }
        }

        public  IEnumerable<User> GetAll()
        {
            return  _unitOfWork.Users.GetAll();
        }

        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        public void Update(User entity)
        {
            _unitOfWork.Users.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

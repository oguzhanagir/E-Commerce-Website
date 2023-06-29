using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Http;
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

        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }


        public void Create(User entity)
        {
            _unitOfWork.Users.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }

        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        public User ValidateUser(string email, string password)
        {
            User user = _unitOfWork.Users.GetUserByEmail(email);

            if (user != null && user.Password == password)
            {
                return user;
            }

            return null!;
        }

        public bool Register(User user)
        {
            if (ValidatePassword(user))
            {
                user.RoleId = 1;
                _unitOfWork.Users.Add(user);
                _unitOfWork.CompleteAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidatePassword(User user)
        {
            if (user == null)
            {
                // Kullanıcı nesnesi null ise hata var, geçerli değil.
                return false;
            }

            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.PasswordConfirm))
            {
                // Şifre veya Şifre Onayı alanlarından biri veya her ikisi boşsa hata var, geçerli değil.
                return false;
            }

            if (user.Password != user.PasswordConfirm)
            {
                // Şifre ve Şifre Onayı alanları eşleşmiyorsa hata var, geçerli değil.
                return false;
            }

            // Yukarıdaki kontrollerden geçtiyse şifre geçerli.
            return true;
        }
        public bool GetCheckEmail(string email)
        {
            var user = _unitOfWork.Users.GetUserByEmail(email);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public void Update(User entity)
        {
            _unitOfWork.Users.Update(entity);
            _unitOfWork.CompleteAsync();
        }


        public User GetUserByMail(string mail)
        {
            var user = _unitOfWork.Users.GetUserByEmail(mail);
            return user;
        }


    }
}

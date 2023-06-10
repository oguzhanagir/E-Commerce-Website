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
    public class ContactService: IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Contact entity)
        {
            _unitOfWork.Contacts.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public  void Delete(int id)
        {
            var about = _unitOfWork.Contacts.GetById(id);
            if (about != null)
            {
                 _unitOfWork.Contacts.Remove(about);
                 _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _unitOfWork.Contacts.GetAllAsync();
        }

        public Contact GetById(int id)
        {
            return _unitOfWork.Contacts.GetById(id);
        }

        public void Update(Contact entity)
        {
            _unitOfWork.Contacts.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

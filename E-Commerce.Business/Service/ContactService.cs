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
            _unitOfWork.Contacts.AddAsync(entity);
            _unitOfWork.CompleteAsync();
        }

        public async void Delete(int id)
        {
            var about = _unitOfWork.Contacts.GetByIdAsync(id);
            if (about != null)
            {
                await _unitOfWork.Contacts.DeleteAsync(about);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _unitOfWork.Contacts.GetAllAsync();
        }

        public Contact GetById(int id)
        {
            return _unitOfWork.Contacts.GetByIdAsync(id);
        }

        public void Update(Contact entity)
        {
            _unitOfWork.Contacts.UpdateAsync(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

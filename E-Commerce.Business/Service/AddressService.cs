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
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Address entity)
        {
            _unitOfWork.Addresses.AddAsync(entity);
            _unitOfWork.CompleteAsync();
        }

        public async void Delete(int id)
        {
            var address = _unitOfWork.Addresses.GetByIdAsync(id);
            if (address != null)
            {
               await _unitOfWork.Addresses.DeleteAsync(address);
               await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _unitOfWork.Addresses.GetAllAsync();
        }

        public Address GetById(int id)
        {
            return _unitOfWork.Addresses.GetByIdAsync(id);
        }

        public void Update(Address entity)
        {
            _unitOfWork.Addresses.UpdateAsync(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

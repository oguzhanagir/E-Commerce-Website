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
            _unitOfWork.Addresses.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var address = _unitOfWork.Addresses.GetById(id);
            if (address != null)
            {
                _unitOfWork.Addresses.Remove(address);
                _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _unitOfWork.Addresses.GetAllAsync();
        }

        public Address GetById(int id)
        {
            return _unitOfWork.Addresses.GetById(id);
        }

        public void Update(Address entity)
        {
            _unitOfWork.Addresses.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

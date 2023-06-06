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
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentMethodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(PaymentMethod entity)
        {
            _unitOfWork.PaymentMethods.AddAsync(entity);
            _unitOfWork.CompleteAsync();
        }

        public async void Delete(int id)
        {
            var paymentMethod = _unitOfWork.PaymentMethods.GetByIdAsync(id);
            if (paymentMethod != null)
            {
                await _unitOfWork.PaymentMethods.DeleteAsync(paymentMethod);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<PaymentMethod>> GetAll()
        {
            return await _unitOfWork.PaymentMethods.GetAllAsync();
        }

        public PaymentMethod GetById(int id)
        {
            return _unitOfWork.PaymentMethods.GetByIdAsync(id);
        }

        public void Update(PaymentMethod entity)
        {
            _unitOfWork.PaymentMethods.UpdateAsync(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}


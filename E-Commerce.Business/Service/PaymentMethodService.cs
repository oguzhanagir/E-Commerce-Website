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
            _unitOfWork.PaymentMethods.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var paymentMethod = _unitOfWork.PaymentMethods.GetById(id);
            if (paymentMethod != null)
            {
                _unitOfWork.PaymentMethods.Remove(paymentMethod);
                _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<PaymentMethod>> GetAll()
        {
            return await _unitOfWork.PaymentMethods.GetAllAsync();
        }

        public PaymentMethod GetById(int id)
        {
            return _unitOfWork.PaymentMethods.GetById(id);
        }

        public void Update(PaymentMethod entity)
        {
            _unitOfWork.PaymentMethods.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}


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
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Payment entity)
        {
            _unitOfWork.Payments.AddAsync(entity);
            _unitOfWork.CompleteAsync();
        }

        public async void Delete(int id)
        {
            var payment = _unitOfWork.Payments.GetByIdAsync(id);
            if (payment != null)
            {
                await _unitOfWork.Payments.DeleteAsync(payment);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Payment>> GetAll()
        {
            return await _unitOfWork.Payments.GetAllAsync();
        }

        public Payment GetById(int id)
        {
            return _unitOfWork.Payments.GetByIdAsync(id);
        }

        public void Update(Payment entity)
        {
            _unitOfWork.Payments.UpdateAsync(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

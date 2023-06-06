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
    public class PaymentStatusService : IPaymentStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(PaymentStatus entity)
        {
            _unitOfWork.PaymentStatuses.AddAsync(entity);
            _unitOfWork.CompleteAsync();
        }

        public async void Delete(int id)
        {
            var payment = _unitOfWork.PaymentStatuses.GetByIdAsync(id);
            if (payment != null)
            {
                await _unitOfWork.PaymentStatuses.DeleteAsync(payment);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<PaymentStatus>> GetAll()
        {
            return await _unitOfWork.PaymentStatuses.GetAllAsync();
        }

        public PaymentStatus GetById(int id)
        {
            return _unitOfWork.PaymentStatuses.GetByIdAsync(id);
        }

        public void Update(PaymentStatus entity)
        {
            _unitOfWork.PaymentStatuses.UpdateAsync(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

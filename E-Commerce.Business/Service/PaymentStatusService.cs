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
            _unitOfWork.PaymentStatuses.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var payment = _unitOfWork.PaymentStatuses.GetById(id);
            if (payment != null)
            {
                _unitOfWork.PaymentStatuses.Remove(payment);
                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<PaymentStatus> GetAll()
        {
            return  _unitOfWork.PaymentStatuses.GetAll();
        }

        public PaymentStatus GetById(int id)
        {
            return _unitOfWork.PaymentStatuses.GetById(id);
        }

        public void Update(PaymentStatus entity)
        {
            _unitOfWork.PaymentStatuses.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

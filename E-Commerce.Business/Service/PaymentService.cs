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
            _unitOfWork.Payments.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var payment = _unitOfWork.Payments.GetById(id);
            if (payment != null)
            {
                _unitOfWork.Payments.Remove(payment);
                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<Payment> GetAll()
        {
            return  _unitOfWork.Payments.GetAll();
        }

        public Payment GetById(int id)
        {
            return _unitOfWork.Payments.GetById(id);
        }

        public void Update(Payment entity)
        {
            _unitOfWork.Payments.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

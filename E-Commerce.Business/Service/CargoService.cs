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
    public class CargoService : ICargoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CargoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Cargo entity)
        {
            var existingCargo = _unitOfWork.Cargoes.Find(c => c.OrderId == entity.OrderId);
            if (existingCargo != null)
            {
                existingCargo.No = entity.No;
                Update(existingCargo);
            }
            else
            {
                _unitOfWork.Cargoes.Add(entity);
                _unitOfWork.CompleteAsync();
            }
        }



        public void Delete(int id)
        {
            var cargo = _unitOfWork.Cargoes.GetById(id);
            if (cargo != null)
            {
                _unitOfWork.Cargoes.Remove(cargo);
                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<Cargo> GetAll()
        {
            return _unitOfWork.Cargoes.GetAll();
        }

        public Cargo GetById(int id)
        {
            return _unitOfWork.Cargoes.GetById(id);
        }

        public void Update(Cargo entity)
        {
            _unitOfWork.Cargoes.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

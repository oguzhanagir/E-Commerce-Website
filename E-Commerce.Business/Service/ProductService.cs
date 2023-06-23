﻿using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Product entity)
        {
            _unitOfWork.Products.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product != null)
            {
                _unitOfWork.Products.Remove(product);
                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var producList =  _unitOfWork.Products.GetAll();
            return producList;
        }

        public  IEnumerable<Product> GetBestSellers()
        {
            var bestSellersList =  _unitOfWork.Products.GetBestSellers().Take(3);
            return bestSellersList;
        }
        public IEnumerable<Product> GetNewArrivalsToThree()
        {
            var bestSellersList = _unitOfWork.Products.GetNewArrivalsToThree();
            return bestSellersList;
        }





        public IEnumerable<Product> GetPopularProducts()
        {
            var popularProducts = _unitOfWork.Products.GetPopularProduct();
            return popularProducts;
        }

        public IEnumerable<Product> GetAllWithCategory()
        {
            var producList = _unitOfWork.Products.GetAll(x => x.Category!,y=>y.ProductImages!);
            return producList;
        }

        public IEnumerable<Product> GetAllWithCategoryById(int id)
        {
            var producList = _unitOfWork.Products.GetAll(x => x.Category!, y => y.ProductImages!).Where(c => c.CategoryId == id);
            return producList;
        }




        public Product GetById(int id)
        {
            return _unitOfWork.Products.GetById(id,x=>x.Category!,y=>y.ProductImages!);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.Categories.GetAll();
        }

        public void Update(Product entity)
        {
            _unitOfWork.Products.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

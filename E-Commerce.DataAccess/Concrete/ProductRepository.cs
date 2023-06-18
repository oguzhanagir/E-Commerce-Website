﻿using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly CommerceDbContext _dbContext;
        public ProductRepository(CommerceDbContext dbContext ): base( dbContext )
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetPopularProduct()
        {
            var popularProducts =  _dbContext.Products!.OrderByDescending(p => p.Price).Take(10).ToList();
            return popularProducts;
        }

        public IEnumerable<Product> GetBestSellers()
        {
            var bestSellers = _dbContext.OrderItems!
                .GroupBy(oi => oi.Id) 
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalSales = g.Sum(oi => oi.Quantity)
                })
                .OrderByDescending(s => s.TotalSales)
                .Take(3)
                .Join(_dbContext.Products!,
                    sale => sale.ProductId,
                    product => product.Id,
                    (sale, product) => product)
                .ToList();

            return bestSellers;
        }


        public IEnumerable<Product> GetNewArrivalsToThree()
        {
            var newArrivals = _dbContext.Products!
                .OrderByDescending(p => p.CreatedAt) // Oluşturulma tarihine göre azalan sırada sıralama
                .Take(3) // İlk 3 ürünü al
                .ToList();

            return newArrivals;
        }

        public async Task<int> GetCountByCategoryId(int categoryId)
        {
            return await _dbContext.Products!.CountAsync(p => p.CategoryId == categoryId);
        }
    }
}

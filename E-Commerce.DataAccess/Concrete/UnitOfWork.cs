using E_Commerce.Core.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly CommerceDbContext _dbContext;

        public UnitOfWork(CommerceDbContext dbContext)
        {
            _dbContext = dbContext;
            Addresses = new AddressRepository(_dbContext);
            Abouts = new AboutRepository(_dbContext);
            Blogs = new BlogRepository(_dbContext);
            Categories = new CategoryRepository(_dbContext);
            Contacts = new ContactRepository(_dbContext);
            OrderItems = new OrderItemRepository(_dbContext);
            Orders = new OrderRepository(_dbContext);
            OrderStatuses = new OrderStatusRepository(_dbContext);
            PaymentMethods = new PaymentMethodRepository(_dbContext);
            Payments = new PaymentRepository(_dbContext);
            PaymentStatuses = new PaymentStatusRepository(_dbContext);
            Products = new ProductRepository(_dbContext);
            Users = new UserRepository(_dbContext);
          
        }

        public IAddressRepository Addresses { get; }
        public IAboutRepository Abouts { get; }

        public IBlogRepository Blogs { get; }

        public ICategoryRepository Categories { get; }
        public IContactRepository Contacts { get; }

        public IOrderItemRepository OrderItems { get; }

        public IOrderRepository Orders { get; }

        public IOrderStatusRepository OrderStatuses { get; }

        public IPaymentMethodRepository PaymentMethods { get; }

        public IPaymentRepository Payments { get; }

        public IPaymentStatusRepository PaymentStatuses { get; }

        public IProductRepository Products { get; }

        public IUserRepository Users { get; }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

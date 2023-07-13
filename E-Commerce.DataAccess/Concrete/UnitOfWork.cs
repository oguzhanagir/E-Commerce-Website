using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Repository.ar;
using E_Commerce.Core.Abstract.Repository.en;
using E_Commerce.Core.Abstract.Repository.ru;
using E_Commerce.DataAccess.Concrete.ar;
using E_Commerce.DataAccess.Concrete.en;
using E_Commerce.DataAccess.Concrete.ru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
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
            Images = new ImageRepository(_dbContext);
            SubCategories = new SubCategoryRepository(_dbContext);
            Carts = new CartRepository(_dbContext);
            Cargoes = new CargoRepository(_dbContext);
            Comments = new CommentRepository(_dbContext);
            Subscribes = new SubscribeRepository(_dbContext);

            CategoryENs = new CategoryENRepository(_dbContext);
            BlogENs = new BlogENRepository(_dbContext);
            ProductENs = new ProductENRepository(_dbContext);
            AboutENs = new AboutENRepository(_dbContext);

            CategoryRUs = new CategoryRURepository(_dbContext);
            BlogRUs = new BlogRURepository(_dbContext);
            ProductRUs = new ProductRURepository(_dbContext);
            AboutRUs = new AboutRURepository(_dbContext);

            CategoryARs = new CategoryARRepository(_dbContext);
            BlogARs = new BlogARRepository(_dbContext);
            ProductARs = new ProductARRepository(_dbContext);
            AboutARs = new AboutARRepository(_dbContext);
            SubCategoryENs = new SubCategoryENRepository(_dbContext);
            SubCategoryARs = new SubCategoryARRepository(_dbContext);
            SubCategoryRUs = new SubCategoryRURepository(_dbContext);
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
        public IImageRepository Images { get; }

        public ISubCategory SubCategories { get; }

        public ICartRepository Carts { get; }

        public ICargoRepository Cargoes { get; }

        public ICommentRepository Comments { get; }

        public ISubscribeRepository Subscribes { get; }




        public ICategoryENRepository CategoryENs { get; }

        public IAboutENRepository AboutENs { get; }

        public IBlogENRepository BlogENs { get; }

        public IProductENRepository ProductENs { get; }

        public ICategoryARRepository CategoryARs { get; }

        public IAboutARRepository AboutARs { get; }

        public IBlogARRepository BlogARs { get; }

        public IProductARRepository ProductARs { get; }

        public ICategoryRURepository CategoryRUs { get; }

        public IAboutRURepository AboutRUs { get; }

        public IBlogRURepository BlogRUs { get; }

        public IProductRURepository ProductRUs { get; }

        public ISubCategoryENRepository SubCategoryENs { get; }

        public ISubCategoryRURepository SubCategoryRUs { get; }

        public ISubCategoryARRepository SubCategoryARs { get; }

        public void CompleteAsync()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

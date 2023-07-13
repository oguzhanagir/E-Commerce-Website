using E_Commerce.Core.Abstract.Repository.ar;
using E_Commerce.Core.Abstract.Repository.en;
using E_Commerce.Core.Abstract.Repository.ru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Addresses { get; }
        IBlogRepository Blogs { get; }
        ICategoryRepository Categories { get; }
        IOrderItemRepository OrderItems { get; }
        IOrderRepository Orders { get; }
        IOrderStatusRepository OrderStatuses { get; }
        IPaymentMethodRepository PaymentMethods { get; }
        IPaymentRepository Payments { get; }
        IPaymentStatusRepository PaymentStatuses { get; }
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        IAboutRepository Abouts { get; }
        IContactRepository Contacts { get; }
        IImageRepository Images { get; }
        ISubCategory SubCategories { get; }
        ICartRepository Carts { get; }
        ICargoRepository Cargoes { get; }
        ICommentRepository Comments { get; }
        ISubscribeRepository Subscribes { get; }


        ICategoryENRepository CategoryENs { get; }
        IAboutENRepository AboutENs { get; }
        IBlogENRepository BlogENs { get; }
        IProductENRepository ProductENs { get; }
        ISubCategoryENRepository SubCategoryENs { get; }
        ISubCategoryRURepository SubCategoryRUs { get; }
        ISubCategoryARRepository SubCategoryARs { get; }

        ICategoryARRepository CategoryARs { get; }
        IAboutARRepository AboutARs { get; }
        IBlogARRepository BlogARs { get; }
        IProductARRepository ProductARs { get; }

        ICategoryRURepository CategoryRUs { get; }
        IAboutRURepository AboutRUs { get; }
        IBlogRURepository BlogRUs { get; }
        IProductRURepository ProductRUs { get; }



        void CompleteAsync();
    }
}

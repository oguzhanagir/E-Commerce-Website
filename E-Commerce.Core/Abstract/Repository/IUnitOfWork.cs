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


       void CompleteAsync();
    }
}

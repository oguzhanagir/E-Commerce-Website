using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CommerceDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//Businees Classes
builder.Services.AddTransient(typeof(IAddressService), typeof(AddressService));
builder.Services.AddTransient(typeof(IBlogService), typeof(BlogService));
builder.Services.AddTransient(typeof(ICategoryService), typeof(CategoryService));
builder.Services.AddTransient(typeof(IOrderItemService), typeof(OrderItemService));
builder.Services.AddTransient(typeof(IOrderService), typeof(OrderService));
builder.Services.AddTransient(typeof(IOrderStatusService), typeof(OrderStatusService));
builder.Services.AddTransient(typeof(IPaymentMethodService), typeof(PaymentMethodService));
builder.Services.AddTransient(typeof(IPaymentService), typeof(PaymentService));
builder.Services.AddTransient(typeof(IPaymentStatusService), typeof(PaymentStatusService));
builder.Services.AddTransient(typeof(IProductService), typeof(ProductService));
builder.Services.AddTransient(typeof(IUserService), typeof(UserService));










var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
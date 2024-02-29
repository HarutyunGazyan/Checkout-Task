using AutoMapper;
using Checkout.DataAccess;
using Checkout.DTOs.Responces;
using Checkout.Middleware;
using Checkout.Models;
using Checkout.Options;
using Checkout.Infrastructure;
using Checkout.Services;
using Checkout.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<CheckoutOptions>(
    builder.Configuration.GetSection("Checkout"));
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CheckoutService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ICheckoutHelper, CheckoutHelper>();

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Product, ProductDTO>()
       .ForMember(dest =>
            dest.Id,
            opt => opt.MapFrom(src => src.Id))
       .ForMember(dest =>
            dest.Name,
            opt => opt.MapFrom(src => src.Name))
       .ForMember(dest =>
            dest.Description,
            opt => opt.MapFrom(src => src.Description))
       .ForMember(dest =>
            dest.ImageUrl,
            opt => opt.MapFrom(src => src.ImageUrl))
       .ForMember(dest =>
            dest.Country,
            opt => opt.MapFrom(src => src.Country))
       .ForMember(dest =>
            dest.Offers,
            opt => opt.MapFrom(src => src.Offers));

    cfg.CreateMap<Offer, OfferDTO>()
       .ForMember(dest =>
            dest.Id,
            opt => opt.MapFrom(src => src.Id))
       .ForMember(dest =>
            dest.Price,
            opt => opt.MapFrom(src => src.Price))
       .ForMember(dest =>
            dest.Name,
            opt => opt.MapFrom(src => src.Name))
       .ForMember(dest =>
            dest.ExtraInfo,
            opt => opt.MapFrom(src => src.ExtraInfo));

}).CreateMapper());

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
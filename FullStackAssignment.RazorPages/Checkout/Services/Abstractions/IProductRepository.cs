using Checkout.Models;

namespace Checkout.Services.Abstractions
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetAsync(int productId);
        Task<Offer> GetOffer(int offerId);
    }
}

using Checkout.DataAccess;
using Checkout.Models;
using Checkout.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Product.Include(p => p.Offers).ToListAsync();
        }

        public async Task<Product> GetAsync(int productId)
        {
            return await _context.Product.Include(p => p.Offers).FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<Offer> GetOffer(int offerId)
        {
            return await _context.Offers.Include(o => o.Product).FirstOrDefaultAsync(o => o.Id == offerId);
        }
    }
}

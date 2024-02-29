using AutoMapper;
using Checkout.DTOs.Responces;
using Checkout.Models;
using Checkout.Pages;
using Checkout.Services.Abstractions;
using Microsoft.CodeAnalysis;

namespace Checkout.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // This is not yet used but can be used in future development
        public async Task<List<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetAsync(int productId)
        {
            var product = await _productRepository.GetAsync(productId);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<List<ProductDTO>> GetProductFacadeAsync()
        {
            var products = await _productRepository.GetAllAsync();

            if (products?.Any() != true)
            {
                return new List<ProductDTO>();
            }

            // It would've been more efficient to do offer filtering at EF Core LINQ layer,
            // but I decided to keep it here in order to make it more maintanable, testable and more evident
            foreach (var product in products)
            {
                //Assuming the lowest price is the cheapest, and ignoring the currency
                var cheapestOffer = product.Offers.OrderBy(o => o.Price).FirstOrDefault();
                product.Offers = new List<Offer> { cheapestOffer };
            }

            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}

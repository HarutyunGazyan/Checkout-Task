using Checkout.Models;

namespace Checkout.DTOs.Responces
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Country Country { get; set; }
        public virtual List<OfferDTO> Offers { get; set; }
    }
}

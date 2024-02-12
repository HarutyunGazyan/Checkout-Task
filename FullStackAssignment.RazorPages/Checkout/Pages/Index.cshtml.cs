using Checkout.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Checkout.Pages
{
    public class IndexModel : PageModel
    {
    }

    public class IndexDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }
        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public string? OfferExtraInfo { get; set; }
        public decimal OfferPrice { get; set; }
        
    }
}

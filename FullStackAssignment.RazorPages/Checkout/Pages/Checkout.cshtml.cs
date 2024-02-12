using Checkout.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Checkout.Pages
{
    public class CheckoutModel : PageModel
    {
    }

    public class CheckoutDto
    {
        public Country Country { get; set; }
        public string ImageUrl { get; set; }
        public string OfferId { get; set; }
        public string OfferName { get; set; }
        public string OfferExtraInfo { get; set; }
    }
}

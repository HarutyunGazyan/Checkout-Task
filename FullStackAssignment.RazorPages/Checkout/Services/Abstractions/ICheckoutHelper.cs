using Checkout.DTOs.Requests;
using Checkout.DTOs.Responces;
using Checkout.Models;

namespace Checkout.Services.Abstractions
{
    public interface ICheckoutHelper
    {
        Task<bool> CheckoutAsync(CheckoutApiRequest request);
    }
}

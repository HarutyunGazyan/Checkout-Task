using Checkout.DTOs.Requests;
using Checkout.DTOs.Responces;
using Checkout.Models;
using Checkout.Services.Abstractions;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace Checkout.Services
{
    public class CheckoutService
    {
        private readonly ICheckoutHelper _checkoutHelper;
        private readonly IProductRepository _productRepository;

        public CheckoutService(ICheckoutHelper checkoutHelper, IProductRepository productRepository)
        {
            _checkoutHelper = checkoutHelper;
            _productRepository = productRepository;
        }

        public async Task<CheckoutResponse> CheckoutAsync(CheckoutRequest request)
        {
            var offer = await _productRepository.GetOffer(request.OfferId);
            if (offer == null)
            {
                return CheckoutResponse.Failure(); // Since there is a validation logic at front-end, this can happen only when somebody tries to hack the app via Postman,
                                                   // thus error details should not be returned from back-end
            }


            if (!IsValid(request, offer.Product.Country))
            {
                return CheckoutResponse.Failure(); // Error details should not be returned from back-end since there is a validation on front-end side
            }

            var apiRequest = new CheckoutApiRequest
            {
                OfferId = request.OfferId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Email = request.Email,
                ZipCode = request.ZipCode,
                Telephone = request.Telephone,
                Country = offer.Product.Country
            };

            var isSuccessful = await _checkoutHelper.CheckoutAsync(apiRequest);

            return isSuccessful ? CheckoutResponse.Success() : CheckoutResponse.Failure();
        }

        private bool IsValid(CheckoutRequest request, Country country) // In case of complex validation I prefer to keep it in business logic layer
                                                                       // over the default Model Validation [Attributes] because this is a part of business logic
        {
            if (request == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(request.FirstName) || // I need more info for better validation
                string.IsNullOrWhiteSpace(request.LastName) ||
                string.IsNullOrWhiteSpace(request.Address) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.ZipCode) ||
                (country != Country.Norway &&
                string.IsNullOrWhiteSpace(request.Telephone)))// This needs a better validation, to validate against country phone number regex
            {
                return false;
            }

            switch (country) // I prefer this approach because each new added country may have different zip length
            {
                case Country.Norway:
                    if (request.ZipCode.Length != 4)
                    {
                        return false;
                    }
                    break;
                case Country.Sweden:
                    if (request.ZipCode.Length != 5)
                    {
                        return false;
                    }
                    break;
                case Country.Finland:
                    if (request.ZipCode.Length != 5)
                    {
                        return false;
                    }
                    break;
                default:
                    throw new NotImplementedException("New Country added to enum without validation logic"); // This exception will be thrown only during development testing
                                                                                                             // and will alert the developer who added a new Country to enum
            }

            return true;
        }
    }
}

using Checkout.DTOs.Requests;
using Checkout.Options;
using Checkout.Services.Abstractions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Checkout.Infrastructure
{
    public class CheckoutHelper : ICheckoutHelper
    {
        private readonly HttpClient _httpClient;
        private readonly CheckoutOptions _options;

        public CheckoutHelper(HttpClient httpClient, IOptions<CheckoutOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<bool> CheckoutAsync(CheckoutApiRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_options.ApiUrl, data);

            return response.IsSuccessStatusCode;
        }
    }
}

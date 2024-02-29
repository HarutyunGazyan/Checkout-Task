using Checkout.DTOs.Requests;
using Checkout.DTOs.Responces;
using Checkout.Services;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : Controller
    {
        private readonly CheckoutService _checkoutService;

        public CheckoutController(CheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CheckoutRequest request)
        {
            var response = await _checkoutService.CheckoutAsync(request);

            if (response.Status == Status.Success)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}

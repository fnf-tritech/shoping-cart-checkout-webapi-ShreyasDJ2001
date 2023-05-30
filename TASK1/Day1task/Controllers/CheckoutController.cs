using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartDiscount.Controllers
{
    [ApiController]
    [Route("api/checkout")]
    public class CheckoutController : ControllerBase
    {
        private readonly CheckoutService checkoutService;

        public CheckoutController()
        {
            checkoutService = new CheckoutService();
        }

        [HttpGet]
        public IActionResult CalculateTotalAmount(string products)
        {
            decimal totalAmount = checkoutService.CalculateTotalAmount(products);
            return Ok(totalAmount);
        }
    }
}

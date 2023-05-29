using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class Checkout
{
    [ApiController]
    [Route("[controller/]")]
    public class CheckoutController : ControllerBase
    {
        private readonly Dictionary<char, int> _itemPrices = new Dictionary<char, int>
    {
        { 'A', 50 },
        { 'B', 30 },
        { 'C', 20 },
        { 'D', 15 }
    };
        private readonly Dictionary<char, int> _itemOffers = new Dictionary<char, int>
    {
        { 'A', 3 },
        { 'B', 2 }
    };

        [HttpGet("{skus}")]
        public IActionResult Get(string skus)
        {
            if (string.IsNullOrEmpty(skus))
            {
                return BadRequest("Invalid SKUs");
            }

            int total = 0;
            int count = 0;

            foreach (char sku in skus)
            {
                if (_itemPrices.ContainsKey(sku))
                {
                    total += _itemPrices[sku];
                    count++;
                }
                else
                {
                    return BadRequest("Invalid SKUs");
                }
            }

            while (count >= 3)
            {
                for (int i = 0; i < count; i++)
                {
                    if (i % 3 == 0)
                    {
                        total -= _itemPrices['A'];
                    }
                }
                count -= 3;
            }

            return Ok(total);
        }
    }


}
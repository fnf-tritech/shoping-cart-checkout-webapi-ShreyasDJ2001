using ShoppingCartDiscount.Models;
using ShoppingCartDiscount.Models;

namespace ShoppingCartDiscount.Controllers
{
    public class CheckoutService
    {
        private readonly List<Item> items;

        public CheckoutService()
        {
            items = new List<Item>
            {
                new Item { Products = 'A', Amount = 50, Discount_Amount = new Discount_Amount { Quantity = 3, Discount_AmountAmount = 130 } },
                new Item { Products = 'B', Amount = 30, Discount_Amount = new Discount_Amount { Quantity = 2, Discount_AmountAmount = 45 } },
                new Item { Products = 'C', Amount = 20 },
                new Item { Products = 'D', Amount = 15 }
            };
        }

        public decimal CalculateTotalAmount(string products)
        {
            var itemCounts = GetItemCounts(products);

            decimal totalAmount = 0;

            foreach (var item in itemCounts)
            {
                var selectedItem = items.FirstOrDefault(i => i.Products == item.Key);
                if (selectedItem != null)
                {
                    totalAmount += CalculateItemAmount(selectedItem, item.Value);
                }
            }

            return totalAmount;
        }

        private Dictionary<char, int> GetItemCounts(string products)
        {
            var itemCounts = new Dictionary<char, int>();

            foreach (char product in products)
            {
                if (!itemCounts.ContainsKey(product))
                {
                    itemCounts[product] = 1;
                }
                else
                {
                    itemCounts[product]++;
                }
            }

            return itemCounts;
        }

        private decimal CalculateItemAmount(Item item, int quantity)
        {
            decimal totalAmount = 0;

            if (item.Discount_Amount != null)
            {
                int discountQuantity = item.Discount_Amount.Quantity;
                int regularQuantity = quantity % discountQuantity;
                int discountAmountQuantity = quantity / discountQuantity;

                totalAmount += discountAmountQuantity * item.Discount_Amount.Discount_AmountAmount;
                totalAmount += regularQuantity * item.Amount;
            }
            else
            {
                totalAmount = quantity * item.Amount;
            }

            return totalAmount;
        }
    }
}
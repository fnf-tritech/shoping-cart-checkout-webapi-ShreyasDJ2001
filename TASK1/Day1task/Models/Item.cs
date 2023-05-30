namespace ShoppingCartDiscount.Models
{
    public class Item
    {
        public char Products { get; set; }
        public decimal Amount { get; set; }
        public Discount_Amount Discount_Amount { get; set; }
    }
}

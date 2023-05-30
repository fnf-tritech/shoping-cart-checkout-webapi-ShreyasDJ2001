using ShoppingCartDiscount;
using ShoppingCartDiscount.Controllers;
using Xunit;

namespace ShoppingCartDiscount.Tests
{
    public class CheckoutServiceTests
    {
        [Fact]
        public void CalculateTotalAmount_SingleItemWithDiscount_ReturnsCorrectTotalAmount()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var products = "BBB"; // 3 items 'B' with discount
            var expectedTotalAmount = 75; // Discounted amount for 3 items 'B'

            // Act
            var actualTotalAmount = checkoutService.CalculateTotalAmount(products);

            // Assert
            Assert.Equal(expectedTotalAmount, actualTotalAmount);
        }

        [Fact]
        public void CalculateTotalAmount_MultipleItemsWithMixedDiscounts_ReturnsCorrectTotalAmount()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var products = "ABC"; // 2 items 'A' with discount, 3 items 'B' with discount
            var expectedTotalAmount =100 ; // Discounted amount for 2 items 'A' + discounted amount for 3 items 'B' + regular amount for other items

            // Act
            var actualTotalAmount = checkoutService.CalculateTotalAmount(products);

            // Assert
            Assert.Equal(expectedTotalAmount, actualTotalAmount);
        }

        [Fact]
        public void CalculateTotalAmount_ItemsWithNoDiscount_ReturnsCorrectTotalAmount()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var products = "AAA"; // No discounts applicable
            var expectedTotalAmount = 130; // Regular amount for all items

            // Act
            var actualTotalAmount = checkoutService.CalculateTotalAmount(products);

            // Assert
            Assert.Equal(expectedTotalAmount, actualTotalAmount);
        }

        [Fact]
        public void CalculateTotalAmount_MultipleItemsWithQuantityDiscount_ReturnsCorrectTotalAmount()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var products = "AAAA"; // 5 items 'A' with discount
            var expectedTotalAmount = 180; // Discounted amount for 5 items 'A'

            // Act
            var actualTotalAmount = checkoutService.CalculateTotalAmount(products);

            // Assert
            Assert.Equal(expectedTotalAmount, actualTotalAmount);
        }
    }
}

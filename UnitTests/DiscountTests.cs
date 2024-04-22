using DotnetUnitTesting;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    public class DiscountTests
    {
        [Test]
        public void User_Able_To_Use_Discount()
        {
            var product = new Product(12, "Simple Product", 3.22, 1);
            var discount = 3;

            var user = new UserAccount("John", "Smith", "1990/10/10");
            user.ShoppingCart.AddProductToCart(product);
            var mockDiscountService = new Mock<IDiscountUtility>();
            mockDiscountService.Setup(s => s.CalculateDiscount(user)).Returns(discount);
            var orderService = new OrderService(mockDiscountService.Object);

            orderService.GetOrderPrice(user).Should().Be(product.Price - discount);
            mockDiscountService.Verify(s => s.CalculateDiscount(user), Times.Once);
            mockDiscountService.VerifyNoOtherCalls();
        }
    }
}

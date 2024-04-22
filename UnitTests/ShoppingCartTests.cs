using DotnetUnitTesting;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests
{
    public class ShoppingCartTests
    {
        private ShoppingCart _shoppingCart;
        private Product _product;

        [SetUp]
        public void SetUp()
        {
            _shoppingCart = new ShoppingCart();
            _product = new Product(12, "Simple Product", 3.22, 1);
            _shoppingCart.AddProductToCart(_product);
        }

        [Test]
        public void User_Can_Add_Single_Product_To_Cart()
        {
            _shoppingCart.Products.Should().NotBeNullOrEmpty();
            _shoppingCart.Products.Should().HaveCount(1);
            _shoppingCart.Products.Single().Id.Should().Be(_product.Id);
            _shoppingCart.Products.Single().Name.Should().Be(_product.Name);
            _shoppingCart.Products.Single().Price.Should().Be(_product.Price);
            _shoppingCart.Products.Single().Quantity.Should().Be(_product.Quantity);
        }

        [Test]
        public void User_Can_Add_Few_Items_Of_Product_To_Cart()
        {
            _shoppingCart.AddProductToCart(_product);

            _shoppingCart.Products.Should().NotBeNullOrEmpty();
            _shoppingCart.Products.Should().HaveCount(1);
            _shoppingCart.Products.Single().Id.Should().Be(_product.Id);
            _shoppingCart.Products.Single().Name.Should().Be(_product.Name);
            _shoppingCart.Products.Single().Price.Should().Be(_product.Price);
            _shoppingCart.Products.Single().Quantity.Should().Be(_product.Quantity);
        }

        [Test]
        public void User_Can_Delete_Product_From_Cart()
        {
            _shoppingCart.AddProductToCart(_product);
            _shoppingCart.AddProductToCart(_product);
            _shoppingCart.RemoveProductFromCart(_product);

            _shoppingCart.Products.Should().BeEmpty();
        }

        [Test]
        public void User_Can_Get_Price_From_Single_Product_In_Cart()
        {
            _shoppingCart.GetCartTotalPrice().Should().Be(_product.Price);
        }

        [Test]
        public void User_Can_Get_Price_Of_Few_Different_Products_In_Cart()
        {
            var additionalProduct = new Product(2, "Additional Product", 4.67, 1);

            _shoppingCart.AddProductToCart(additionalProduct);

            _shoppingCart.GetCartTotalPrice().Should().Be(additionalProduct.Price + _product.Price);
        }

        [Test]
        public void User_Can_Get_Price_Of_Few_Items_Of_Product_In_Cart()
        {
            _shoppingCart.AddProductToCart(_product);

            _shoppingCart.GetCartTotalPrice().Should().Be(_product.Price * 2);
        }
    }
}

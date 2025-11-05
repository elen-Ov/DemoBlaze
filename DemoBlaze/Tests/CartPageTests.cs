using DemoBlaze.Models;
using DemoBlaze.Pages;
using DemoBlaze.Services;
using DemoBlaze.Utils;
using Allure.NUnit.Attributes;
using MyAllure = Allure.NUnit;

namespace DemoBlaze.Tests;

[MyAllure.AllureNUnit]

public class CartPageTests : BaseTest
{
    private readonly ProductPage _productPage = new ProductPage();
    private readonly CartPage _cartPage = new CartPage();
    private readonly CartService _cartService = new CartService();

    [Test]
    [Category("Cart tests")]
    [Category("QA")]
    [AllureTag("smoke")]
    [AllureOwner("Elena Ov")]
    [AllureSuite("Products' image url, title and price data in cart check")]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.GetTestCasesForCartPage))]
    public void CartPage_CheckProductsAddedToCartData_Success(string imageUrl, string title, string price)
    {
        // Arrange
        var isCartEmpty = _cartService.GetCartState();
        _cartService.AddProductsToCart(title);
        
        // Act
        _productPage.ClickCartLink();
        var isOpen = _cartPage.IsCartPageOpen();
        var itemInCartImage = _cartPage.GetProductInCartImageUrl(imageUrl);
        var itemInCartName = _cartPage.GetProductInCartTitle(title);
        var itemInCartPrice = _cartPage.GetProductInCartPrice(price);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(isCartEmpty, Is.True, "Cart is not empty");
            Assert.That(isOpen, Is.True, "Cart Page is not open");
            Assert.That(itemInCartImage, Does.Contain(imageUrl), $"Actual product image url: {itemInCartImage} doesn't contain {imageUrl}");
            Assert.That(itemInCartName, Is.EqualTo(title), $"Expected title: {title}, but got: {itemInCartName}");
            Assert.That(itemInCartPrice, Is.EqualTo(price), $"Expected price: {price}, but got: {itemInCartPrice}");
        });
    }
    
    [Test]
    [Category("Cart tests")]
    [Category("QA")]
    [AllureTag("regression")]
    [AllureOwner("Elena Ov")]
    [AllureSuite("Ability to add several products to cart check")]
    public void CartPage_AddSeveralProductsToCart_Success()
    {
        // Arrange
        var expectedProductsList = new List<ProductInCart>
        {
            new ProductInCart(
                "https://www.demoblaze.com/imgs/Lumia_1520.jpg",
                "Nokia lumia 1520",
                "820"),
            new ProductInCart(
                "https://www.demoblaze.com/imgs/galaxy_s6.jpg",
                "Samsung galaxy s6",
                "360")
        };
        _cartService.GetCartState();
  
        // Act
        _cartService.AddProductsToCart("Nokia lumia 1520", "Samsung galaxy s6");
        _productPage.ClickCartLink();
        _cartPage.IsCartPageOpen();
        var actualProductsList = _cartPage.GetProductsInCartList();
        
        // Assert
        Assert.That(actualProductsList, Is.EquivalentTo(expectedProductsList), 
            "Expected products list isn't equal to the actual list.");
    }

    [Test]
    [Category("Cart tests")]
    [Category("QA")]
    [AllureTag("regression")]
    [AllureOwner("Elena Ov")]
    [AllureSuite("Ability to delete several products in cart check")]
    [TestCase("Nokia lumia 1520")]
    [TestCase("Nexus 6", "Samsung galaxy s6")]
    public void CartPage_DeleteProductsInCart_Success(params string[] productNames)
    {
        // Arrange
        _cartService.AddProductsToCart(productNames);
  
        // Act
        _productPage.ClickCartLink();
        _cartPage.IsCartPageOpen();
        _cartPage.DeleteProductInCart(productNames);
        
        // Assert
        var isEmpty = _cartPage.IsCartEmpty();
        Assert.That(isEmpty, Is.True, "Cart isn't empty after deletion.");
    }
}
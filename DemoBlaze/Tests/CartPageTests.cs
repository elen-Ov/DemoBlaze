using DemoBlaze.Pages;
using DemoBlaze.SeleniumFramework;

namespace DemoBlaze.Tests;

public class CartPageTests : BaseTest
{
    private readonly AlertElement _loginAlert = new AlertElement();
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();
    private readonly ProductPage _productPage = new ProductPage();
    private readonly CartPage _cartPage = new CartPage();

    [Test]
    public void Cart_CheckOneProductAddedToCart_Success()
    {
        // Arrange
        _mainPage.IsMainPageOpen();
        _mainPage.ChooseProduct("Nokia lumia 1520");
        _cartPage.IsCartEmpty();
        
        // Act
        _productPage.ClickAddToCartButton();
        _loginAlert.AlertAccept();
        _productPage.ClickCartLink();
        
        // Assert
        var isOpen = _cartPage.IsCartPageOpen();
    }
}
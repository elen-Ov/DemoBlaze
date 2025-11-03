using DemoBlaze.Pages;
using DemoBlaze.SeleniumFramework;

namespace DemoBlaze.Tests;

public class ProductPageTests : BaseTest
{
    private readonly AlertElement _loginAlert = new AlertElement();
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();
    private readonly ProductPage _productPage = new ProductPage();
    
    [Test]
    public void Product_AddProductInStockToCart_Success()
    {
        // похорошему логинимся
        // Arrange
        _mainPage.IsMainPageOpen();
        _mainPage.ChooseProduct("Nokia lumia 1520");

        // Act
        // товар всегда один на странице продукта
        var name = _productPage.GetProductName();
        var price = _productPage.GetProductPrice();
        var description = _productPage.GetProductDescription();
        _productPage.ClickAddToCartButton();
        var alertMessage = _loginAlert.GetAlertText();
        _loginAlert.AlertAccept();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(name, Is.EqualTo("Nokia lumia 1520"), 
                "Actual and expected product names aren't equal.");
            Assert.That(price, Is.EqualTo("$820 *includes tax"), 
                "Actual and expected prices aren't equal.");
            Assert.That(description, Is.EqualTo(
                "The Nokia Lumia 1520 is powered by 2.2GHz quad-core Qualcomm Snapdragon 800 processor " +
                "and it comes with 2GB of RAM."), "Actual and expected descriptions aren't equal.");
            Assert.That(alertMessage, Is.EqualTo("Product added"), 
                "Alert message should be equal to expected.");
        });
    }
}
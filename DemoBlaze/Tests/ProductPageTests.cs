using Allure.NUnit.Attributes;
using MyAllure = Allure.NUnit;
using DemoBlaze.Pages;
using DemoBlaze.SeleniumFramework;
using DemoBlaze.Utils;

namespace DemoBlaze.Tests;

[MyAllure.AllureNUnit]

public class ProductPageTests : BaseTest
{
    private readonly AlertElement _loginAlert = new AlertElement();
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();
    private readonly ProductPage _productPage = new ProductPage();
    
    [Test]
    [Category("Product page tests")]
    [Category("QA")]
    [AllureTag("smoke")]
    [AllureOwner("Elena Ov")]
    [AllureSuite("Ability to add product to cart check")]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.GetTestCasesForProductPage))]
    public void ProductPage_AddProductInStockToCart_Success(string title, string price, string description)
    {
        // Arrange
        _mainPage.IsMainPageOpen();
        _mainPage.ChooseProduct(title);

        // Act
        var productName = _productPage.GetProductName();
        var productPrice = _productPage.GetProductPrice();
        var productDescription = _productPage.GetProductDescription();
        _productPage.ClickAddToCartButton();
        var alertMessage = _loginAlert.GetAlertText();
        _loginAlert.AlertAccept();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(productName, Is.EqualTo(title), 
                $"Expected title: {title}, but got: {productName}.");
            Assert.That(productPrice, Is.EqualTo(price), 
                $"Expected price: {price}, but got: {productPrice}.");
            Assert.That(productDescription, Is.EqualTo(description),
                $"Expected description: {description}, but got: {productDescription}.");
            Assert.That(alertMessage, Is.EqualTo("Product added"), 
                "Alert message should be equal to expected.");
        });
    }
}
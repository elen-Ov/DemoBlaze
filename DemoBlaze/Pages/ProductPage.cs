using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;
using Allure.NUnit.Attributes;

namespace DemoBlaze.Pages;

public class ProductPage : BasePage
{
    private readonly By _productNameLocator = By.CssSelector("h2.name");
    private readonly By _productPriceLocator = By.CssSelector("h3.price-container");
    private readonly By _productDescriptionLocator = By.CssSelector("#more-information p");
    private readonly By _addToCartButton = By.XPath("//a[text()='Add to cart']");
    private readonly By _cartLinkLocator = By.Id("cartur");
    private readonly By _homeLinkLocator = By.XPath("//a[@href='index.html']");
    
    [AllureStep("Получение наименования товара")]
    public string GetProductName()
    {
        return new BaseElement(_productNameLocator).GetText();
    }
    
    [AllureStep("Получение цены товара")]
    public string GetProductPrice()
    {
        return new BaseElement(_productPriceLocator).GetText();
    }
    
    [AllureStep("Получение описания товара")]
    public string GetProductDescription()
    {
        return new BaseElement(_productDescriptionLocator).GetText();
    }

    [AllureStep("Клик по кнопке 'добавить в корзину'")]
    public void ClickAddToCartButton()
    {
        var buttonLocator = new ButtonElement(_addToCartButton);
        buttonLocator.ClickIfDisplayed();
    }
    
    [AllureStep("Клик по кнопке 'корзина'")]
    public void ClickCartLink()
    {
        var cartLink = new LinkElement(_cartLinkLocator);
        cartLink.ClickIfDisplayed();
    }

    [AllureStep("Переход на главную страницу")]
    public void GoToHomePage()
    {
        var homeLink = new LinkElement(_homeLinkLocator);
        homeLink.ClickIfDisplayed();
    }
}
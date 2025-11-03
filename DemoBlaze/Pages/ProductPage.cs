using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;

namespace DemoBlaze.Pages;

public class ProductPage : BasePage
{
    private readonly By _productNameLocator = By.CssSelector("h2.name");
    private readonly By _productPriceLocator = By.CssSelector("h3.price-container");
    private readonly By _productDescriptionLocator = By.CssSelector("#more-information p");
    private readonly By _addToCartButton = By.XPath("//a[text()='Add to cart']");
    private readonly By _cartLinkLocator = By.Id("cartur");
    
    public string GetProductName()
    {
        return new BaseElement(_productNameLocator).GetText();
    }
    
    public string GetProductPrice()
    {
        return new BaseElement(_productPriceLocator).GetText();
    }
    
    public string GetProductDescription()
    {
        return new BaseElement(_productDescriptionLocator).GetText();
    }

    public void ClickAddToCartButton()
    {
        var buttonLocator = new ButtonElement(_addToCartButton);
        buttonLocator.ClickIfDisplayed();
    }
    
    public void ClickCartLink()
    {
        var linkLocator = new LinkElement(_cartLinkLocator);
        linkLocator.ClickIfDisplayed();
    }
}
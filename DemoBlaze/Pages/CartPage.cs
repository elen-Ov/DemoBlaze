using DemoBlaze.Models;
using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;

namespace DemoBlaze.Pages;

public class CartPage : BasePage
{
    private readonly By _cartPageLabel = By.XPath("//h2[text()='Products']");
    private readonly By _totalPriceLabel = By.Id("totalp");
    private readonly By _cartTable = By.Id("tbodyid");

    public bool IsCartPageOpen()
    {
        try
        {
            var label = new BaseElement(_cartPageLabel);
            return label.IsDisplayed();
        }
        catch (WebDriverException ex) when 
            (ex is NoSuchElementException || 
             ex is StaleElementReferenceException) // элемент был найден, но исчез
        {
            return false;
        }
    }

    public bool IsCartEmpty()
    {
        try
        {
            var totalPriceElement = new BaseElement(_totalPriceLabel);
            string totalPrice = totalPriceElement.GetText();
            return string.IsNullOrEmpty(totalPrice);
        }
        catch (WebDriverException ex) when 
            (ex is NoSuchElementException || 
             ex is StaleElementReferenceException)
        {
            return true;
        }
    }

    /*public List<Product> GetProductsInCartList()
    {
        var products = new List<Product>();
    }*/
}
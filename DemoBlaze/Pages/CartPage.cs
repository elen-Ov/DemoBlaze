using DemoBlaze.Models;
using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.String;
using Allure.NUnit.Attributes;

namespace DemoBlaze.Pages;

public class CartPage : BasePage
{
    private readonly By _cartPageLabel = By.XPath("//h2[text()='Products']");
    //private readonly By _totalPriceLabel = By.Id("totalp");
    private readonly By _cartTable = By.Id("tbodyid");
    private readonly By _cartTableRows = By.TagName("tr");
    private readonly By _cartTableCells = By.TagName("td");
    private readonly By _homeLink = By.XPath("//a[@href='index.html']");
    private readonly By _tableLine = By.XPath("//tr[@class='success']"); // если товар есть в корзине
    private readonly By _deleteLink = By.XPath(".//a[text()='Delete']");
    // product templates
    private readonly string _productInCartImage = "//img[contains(@src, '{0}')]";
    private readonly string _productInCartName = "//td[text()='{0}']";
    private readonly string _productInCartPrice = "//td[text()='{0}']";

    private LinkElement HomeLinkLocator => new LinkElement(_homeLink);
    
    [AllureStep("Проверка открытия страницы корзины")]
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
    
    [AllureStep("Проверка состояния корзины")]
    public bool IsCartEmpty()
    {
        try
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(_tableLine).Count == 0);
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
    
    [AllureStep("Переход на главную страницу")]
    public void GoToHomePage()
    {
        var homePage = HomeLinkLocator;
        homePage.ClickElement();
    }
    
    public List<ProductInCart> GetProductsInCartList()
    {
        var productsInCartList = new List<ProductInCart>();
        var table = Driver.FindElement(_cartTable);
        var tableRows = table.FindElements(_cartTableRows);
        foreach (var row in tableRows)
        {
            var cells = row.FindElements(_cartTableCells);
            productsInCartList.Add(new ProductInCart(
                image: cells[0]?.FindElement(By.TagName("img")).GetAttribute("src"),
                title: cells[1]?.Text,
                price: cells[2]?.Text));
        }
        return productsInCartList;
    }
    
    [AllureStep("Получение ссылки изображения товара")]
    public string? GetProductInCartImageUrl(string imageUrl)
    {
        var productImageUrl  = Driver.FindElement(By.XPath(Format(_productInCartImage, imageUrl)));
        return productImageUrl.GetAttribute("src");
    }
    
    [AllureStep("Получение названия товара")]
    public string GetProductInCartTitle(string title)
    {
        var productName = Driver.FindElement(By.XPath(Format(_productInCartName, title)));
        return productName.Text;
    }
    
    [AllureStep("Получение цены товара")]
    public string GetProductInCartPrice(string price)
    {
        var productPrice = Driver.FindElement(By.XPath(Format(_productInCartPrice, price)));
        return productPrice.Text;
    }
    
    [AllureStep("Удаление товара из корзины")]
    public void DeleteProductInCart(params string[] productNames)
    {
        foreach (var name in productNames)
        {
            try
            {
                var productRow = Driver.FindElement(
                    By.XPath($"//tr[contains(@class, 'success')][.//td[text()='{name}']]")
                );
                var deleteBtn = productRow.FindElement(_deleteLink);
                new WebDriverWait(Driver, TimeSpan.FromSeconds(5))
                    .Until(d => deleteBtn.Displayed && deleteBtn.Enabled);
                deleteBtn.Click();
                new WebDriverWait(Driver, TimeSpan.FromSeconds(5))
                    .Until(d => 
                    {
                        try
                        {
                            return productRow.FindElements(_deleteLink).Count == 0;
                        }
                        catch (StaleElementReferenceException)
                        {
                            return true;
                        }
                    });
            }
            catch (NoSuchElementException ex)
            {
                throw new Exception($"Не удалось найти товар '{name}' для удаления", ex);
            }
        }
    }
}
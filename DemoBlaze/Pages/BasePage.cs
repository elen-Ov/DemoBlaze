using OpenQA.Selenium;
using DemoBlaze.Utils;

namespace DemoBlaze.Pages;

public class BasePage
{
    //private readonly string _baseUrl = "https://www.demoblaze.com/";
    
    protected IWebDriver Driver => BrowserUtils.Driver;
    
    // открытие сайта
    protected void OpenProductStoreMainPage()
    {
        Driver.Navigate().GoToUrl(Config.BaseUrl);
    }
}
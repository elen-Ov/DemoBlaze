using OpenQA.Selenium;
using DemoBlaze.Utils;

namespace DemoBlaze.Pages;

public class BasePage
{
    protected IWebDriver Driver => BrowserUtils.Driver;
    
    protected void OpenProductStoreMainPage()
    {
        Driver.Navigate().GoToUrl(Config.BaseUrl);
    }
}
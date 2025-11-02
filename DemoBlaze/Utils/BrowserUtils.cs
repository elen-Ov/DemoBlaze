using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoBlaze.Utils;

public class BrowserUtils
{
    private static IWebDriver? _driver;

    public static IWebDriver Driver
    {
        get
        {
            if (_driver == null)
            {
                _driver = Init();
            }
            return _driver;
        }
    }

    private static IWebDriver Init()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        return driver;
    }

    public static void CloseBrowser()
    {
        _driver?.Quit();
        _driver?.Dispose();
        _driver = null;
    }
}
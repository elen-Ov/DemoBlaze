using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoBlaze.SeleniumFramework;

public class BaseElement
{
    protected readonly IWebDriver Driver = Utils.BrowserUtils.Driver;
    protected readonly By Locator;
    protected readonly WebDriverWait Wait;
    
    public BaseElement(int timeOutSeconds = 10)
    {
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutSeconds));
    }
    public BaseElement(By locator, int timeOutSeconds = 10)
    {
        Locator = locator;
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutSeconds));
    }
    
    public IWebElement Element => Wait.Until(driver => driver.FindElement(Locator));
    
    public bool IsDisplayed()
    {
        return Element.Displayed;
    }
    
    public void ClickElement()
    {
        Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Locator)).Click();
    }
    
    public void SetUpText(string text)
    {
        Element.Clear();
        Element.SendKeys(text);
    }
}
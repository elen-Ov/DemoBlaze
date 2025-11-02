using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoBlaze.SeleniumFramework;

public class ButtonElement : BaseElement
{
    public ButtonElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }
    
    public void ClickIfDisplayed()
    {
        if (IsDisplayed())
        {
            ClickElement(); 
        }
        else
        {
            throw new Exception("Button is not clickable");
        }
    }
    
    public void WaitUntilClickable(int timeoutSeconds = 30)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Locator));
    } 
}
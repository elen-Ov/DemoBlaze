using DemoBlaze.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoBlaze.SeleniumFramework;

public class AlertElement : BaseElement
{
    protected IWebDriver Driver = BrowserUtils.Driver;
    
    public AlertElement(int timeOutSeconds = 10) : base(timeOutSeconds) { }
    
    public bool IsAlertPresent(int timeOutSeconds = 10)
    {
        try
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutSeconds))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public void AlertAccept()
    {
        if (IsAlertPresent())
        {
            Driver.SwitchTo().Alert().Accept();
        }
        else
        {
            throw new Exception("Alert not present");
        } 
    }

    public void AlertDismiss()
    {
        if (IsAlertPresent())
        {
            Driver.SwitchTo().Alert().Dismiss();
        }
        else
        {
            throw new Exception("Alert not present");
        } 
    }

    public string? GetAlertText()
    {
        if (IsAlertPresent())
        {
            return Driver.SwitchTo().Alert().Text;
        }
        throw new Exception("Alert not present");
    }
}
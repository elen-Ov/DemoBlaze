using OpenQA.Selenium;

namespace DemoBlaze.SeleniumFramework;

public class LinkElement : BaseElement
{
    public LinkElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }
    
    public void ClickIfDisplayed()
    {
        if (IsDisplayed())
        {
            ClickElement(); 
        }
        else
        {
            throw new Exception("Link is not visible or not clickable");
        }
    }
}
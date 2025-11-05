using OpenQA.Selenium;

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
}
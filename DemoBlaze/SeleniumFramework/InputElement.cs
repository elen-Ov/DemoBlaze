using OpenQA.Selenium;

namespace DemoBlaze.SeleniumFramework;

public class InputElement : BaseElement
{
    public InputElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }
}
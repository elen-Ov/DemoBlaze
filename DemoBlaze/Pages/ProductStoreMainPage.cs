using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;

namespace DemoBlaze.Pages;

public class ProductStoreMainPage : BasePage
{
    private readonly By _logInButtonLocator = By.Id("login2");
    private readonly By _signUpButtonLocator = By.Id("signin2");

    public void ClickLoginButton()
    {
        var loginButton = new ButtonElement(_logInButtonLocator);
        loginButton.ClickIfDisplayed();
    }
    
    public void ClickSignUpButton()
    {
        var signUpButton = new ButtonElement(_signUpButtonLocator);
        signUpButton.ClickIfDisplayed();
    }
}
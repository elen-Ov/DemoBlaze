using DemoBlaze.Models;
using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;
using Allure.NUnit.Attributes;

namespace DemoBlaze.Pages.Forms;

public class LogInForm
{
    private readonly By _loginFieldUsernameLocator = By.Id("loginusername");
    private readonly By _passwordFieldLocator = By.Id("loginpassword");
    private readonly By _loginButtonLocator = By.XPath("//button[text()='Log in']");
    
    private InputElement LoginFieldUsernameInput => new InputElement(_loginFieldUsernameLocator);
    private InputElement LoginFieldPasswordInput => new InputElement(_passwordFieldLocator);
    private ButtonElement LoginButton => new ButtonElement(_loginButtonLocator);
    
    [AllureStep("Логин пользователя")]
    public LogInForm LoginUser(User user)
    {
        LoginFieldUsernameInput.SetUpText(user.Username);
        LoginFieldPasswordInput.SetUpText(user.Password);
        LoginButton.ClickIfDisplayed();
        return this;
    }
}
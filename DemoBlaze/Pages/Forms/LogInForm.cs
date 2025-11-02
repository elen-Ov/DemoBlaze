using DemoBlaze.Models;
using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;

namespace DemoBlaze.Pages.Forms;

public class LogInForm
{
    private readonly By _loginFieldUsernameLocator = By.Id("loginusername");
    private readonly By _passwordFieldLocator = By.Id("loginpassword");
    private readonly By _loginButtonLocator = By.XPath("//button[text()='Log in']");
    
    public InputElement LoginFieldUsernameInput => new InputElement(_loginFieldUsernameLocator);
    public InputElement LoginFieldPasswordInput => new InputElement(_passwordFieldLocator);
    public ButtonElement LoginButton => new ButtonElement(_loginButtonLocator);
    
    public LogInForm LoginUser(User user)
    {
        LoginFieldUsernameInput.SetUpText(user.Username);
        LoginFieldPasswordInput.SetUpText(user.Password);
        LoginButton.ClickElement();
        return this;
    }
}
using DemoBlaze.Models;
using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;

namespace DemoBlaze.Pages.Forms;

public class SignUpForm
{
    private readonly By _signUpFieldUsernameLocator = By.Id("sign-username");
    private readonly By _signUpPasswordFieldLocator = By.Id("sign-password");
    private readonly By _signUpButtonLocator = By.XPath("//button[text()='Sign up']");
    
    public InputElement SignUpFieldUsernameInput => new InputElement(_signUpFieldUsernameLocator);
    public InputElement SignUpFieldPasswordInput => new InputElement(_signUpPasswordFieldLocator);
    public ButtonElement SignUpButtonConfirmation => new ButtonElement(_signUpButtonLocator);
    
    public void SignUpUser(User user)
    {
        SignUpFieldUsernameInput.SetUpText(user.Username);
        SignUpFieldPasswordInput.SetUpText(user.Password);
        SignUpButtonConfirmation.ClickIfDisplayed();
    }
}
using DemoBlaze.Models;
using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;
using Allure.NUnit.Attributes;

namespace DemoBlaze.Pages.Forms;

public class SignUpForm
{
    private readonly By _signUpFieldUsernameLocator = By.Id("sign-username");
    private readonly By _signUpPasswordFieldLocator = By.Id("sign-password");
    private readonly By _signUpButtonLocator = By.XPath("//button[text()='Sign up']");
    
    private InputElement SignUpFieldUsernameInput => new InputElement(_signUpFieldUsernameLocator);
    private InputElement SignUpFieldPasswordInput => new InputElement(_signUpPasswordFieldLocator);
    private ButtonElement SignUpButtonConfirmation => new ButtonElement(_signUpButtonLocator);
    
    [AllureStep("Регистрация пользователя")]
    public void SignUpUser(User user)
    {
        SignUpFieldUsernameInput.SetUpText(user.Username);
        SignUpFieldPasswordInput.SetUpText(user.Password);
        SignUpButtonConfirmation.ClickIfDisplayed();
    }
}
using DemoBlaze.Builders;
using DemoBlaze.Pages;
using DemoBlaze.Pages.Forms;
using DemoBlaze.SeleniumFramework;

namespace DemoBlaze.Tests;

public class LoginTests : BaseTest
{
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();
    private readonly LogInForm _loginForm = new LogInForm();
    private readonly AlertElement _loginAlert = new AlertElement();

    [Test]
    public void Login_ValidDataTest()
    {
        _mainPage.ClickLoginButton();
        var user = new UserBuilder()
            .WithUsername("user_test_559")
            .WithPassword("testpassword_559")
            .Build();
        _loginForm.LoginUser(user);
    }
    
    [Test]
    public void Login_NotRegisteredUserTest()
    {
        // arrange
        _mainPage.ClickLoginButton();
        var user = new UserBuilder()
            .WithUsername("user_test_559")
            .WithPassword("testpassword_559")
            .Build();
        _loginForm.LoginUser(user);
        _loginAlert.IsAlertPresent();
        // act
        var alertMessage = _loginAlert.GetAlertText();
        _loginAlert.AlertAccept();
        // assert
        Assert.That(alertMessage, Is.EqualTo("User does not exist."), 
            "Actual alert message isn't equal to expected.");
    }
}
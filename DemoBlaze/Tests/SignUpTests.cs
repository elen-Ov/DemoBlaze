using DemoBlaze.Models;
using DemoBlaze.Pages;
using DemoBlaze.SeleniumFramework;
using DemoBlaze.Services;
using DemoBlaze.Utils;

namespace DemoBlaze.Tests;

public class SignUpTests : BaseTest
{
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();
    private readonly UserService _userService = new UserService();
    private readonly AlertElement _loginAlert = new AlertElement();

    [Test]
    public void Register_ValidUser_Success()
    {
        // Arrange
        var user = new User("user_test_113", "testpassword_113");

        // Act
        _userService.Register(user);
        _loginAlert.IsAlertPresent();
        var alertMessage = _loginAlert.GetAlertText();
        _loginAlert.AlertAccept();
        
        // Assert
        Assert.That(alertMessage, Is.EqualTo("Sign up successful."), 
            "Actual alert message isn't equal to expected.");
    }
    
    [Test]
    public void Register_AlreadyRegisteredUser_Failure()
    {
        // Arrange
        var user = new User(Config.Username, Config.Password);

        // Act
        _userService.Register(user);
        _loginAlert.IsAlertPresent();
        var alertMessage = _loginAlert.GetAlertText();
        _loginAlert.AlertAccept();
        
        // Assert
        Assert.That(alertMessage, Is.EqualTo("This user already exist."), 
            "Actual alert message isn't equal to expected.");
    }
}
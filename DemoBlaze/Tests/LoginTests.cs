using DemoBlaze.Models;
using DemoBlaze.Pages;
using DemoBlaze.SeleniumFramework;
using DemoBlaze.Services;
using DemoBlaze.Utils;

namespace DemoBlaze.Tests;

public class LoginTests : BaseTest
{
    private readonly AlertElement _loginAlert = new AlertElement();
    private readonly UserService _userService = new UserService();
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();

    // сценарий с logout
    [Test]
    public void Login_ValidCredentials_Success()
    {
        // Arrange
        var user = new User(Config.Username, Config.Password);

        // Act
        _userService.Login(user);

        // Assert
        Assert.That(_mainPage.GetWelcomeMessage(), 
            Is.EqualTo($"Welcome {Config.Username}"),
            "Welcome message was not displayed or incorrect");
    }

    [Test]
    public void Login_NotRegisteredUser_Failure()
    {
        // Arrange
        var user = new User("fff_1111", "nnn");

        // Act
        _userService.Login(user);
        _loginAlert.IsAlertPresent();
        var alertMessage = _loginAlert.GetAlertText();
        _loginAlert.AlertAccept();
        
        // Assert
        Assert.That(alertMessage, Is.EqualTo("User does not exist."), 
            "Actual alert message isn't equal to expected.");
    }
}
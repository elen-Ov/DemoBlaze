using DemoBlaze.Models;
using DemoBlaze.Pages;
using DemoBlaze.SeleniumFramework;
using DemoBlaze.Services;
using DemoBlaze.Utils;
using Allure.NUnit.Attributes;
using MyAllure = Allure.NUnit;

namespace DemoBlaze.Tests;

[MyAllure.AllureNUnit]

public class LoginTests : BaseTest
{
    private readonly UserService _userService = new UserService();
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();
    
    [Test]
    [Category("Login tests")]
    [Category("QA")]
    [AllureTag("regression")]
    [AllureOwner("Elena Ov")]
    [AllureSuite("Login with valid credentials")]
    public void LoginForm_LogInWithValidCredentials_Success()
    {
        // Arrange
        var user = new User(Config.Username, Config.Password);

        // Act
        _userService.Login(user);
        var welcomeMessage = _mainPage.GetWelcomeMessage();

        // Assert
        Assert.That(welcomeMessage, Is.EqualTo($"Welcome {Config.Username}"),
            "Welcome message was not displayed or incorrect");
    }

    [Test]
    [Category("Login tests")]
    [Category("QA")]
    [AllureTag("smoke")]
    [AllureOwner("Elena Ov")]
    [AllureSuite("Login by not registered user")]
    public void LoginForm_LogInByNotRegisteredUser_ErrorMessage()
    {
        // Arrange
        var user = new User("ddd_1234567", "ddd_1234567");

        // Act
        _userService.Login(user);
        var loginAlert = new AlertElement();
        var alertMessage =  loginAlert.GetAlertText();
        loginAlert.AlertAccept();
        
        // Assert
        Assert.That(alertMessage, Is.EqualTo("User does not exist."), 
            "Actual alert message isn't equal to expected.");
    }
    
    [Test]
    [Category("Login tests")]
    [Category("QA")]
    [AllureTag("regression")]
    [AllureOwner("Elena Ov")]
    [AllureSuite("Login with empty fields")]
    [TestCase("", "")]
    [TestCase("fff_1111", "")]
    [TestCase("", "fff_1111")]
    public void LoginForm_LogInWithEmptyFields_ErrorMessage(string username, string password)
    {
        // Arrange
        var user = new User(username, password);
        
        // Act
        _userService.Login(user);
        var loginAlert = new AlertElement();
        var alertMessage =  loginAlert.GetAlertText();
        loginAlert.AlertAccept();
        
        // Assert
        Assert.That(alertMessage, Is.EqualTo("Please fill out Username and Password."),
            "Actual alert message isn't equal to expected.");
    }
}
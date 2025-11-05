using DemoBlaze.Models;
using DemoBlaze.Pages;
using DemoBlaze.SeleniumFramework;
using DemoBlaze.Services;
using DemoBlaze.Utils;
using Allure.NUnit.Attributes;
using MyAllure = Allure.NUnit;

namespace DemoBlaze.Tests;

[MyAllure.AllureNUnit]

public class SignUpTests : BaseTest
{
    private readonly UserService _userService = new UserService();
    private readonly AlertElement _loginAlert = new AlertElement();

    [Test]
    [Category("Sign up tests")]
    [Category("QA")]
    [AllureTag("regression")]
    [AllureOwner("Elena Ov")]
    [AllureSuite("Register with valid credentials")]
    public void SignUp_RegisterWithValidData_Success()
    {
        // Arrange
        var user = StringUtils.GenerateUserNameAndPassword(6);
        var userData = new User(user.Name, user.Password);

        // Act
        _userService.Register(userData);
        _loginAlert.IsAlertPresent();
        var alertMessage = _loginAlert.GetAlertText();
        _loginAlert.AlertAccept();
        
        // Assert
        Assert.That(alertMessage, Is.EqualTo("Sign up successful."), 
            "Actual alert message isn't equal to expected.");
    }
    
    [Test]
    [Category("Sign up tests")]
    [Category("QA")]
    [AllureTag("regression")]
    [AllureOwner("Elena Ov")]
    [AllureSuite("Register with valid credentials twice")]
    public void SignUp_RegisterByAlreadyRegisteredData_ErrorMessage()
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
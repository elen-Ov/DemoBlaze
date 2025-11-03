using DemoBlaze.Models;
using DemoBlaze.Pages;
using DemoBlaze.SeleniumFramework;
using DemoBlaze.Services;
using DemoBlaze.Utils;

namespace DemoBlaze.Tests;

public class ContactTests : BaseTest
{
    private readonly AlertElement _loginAlert = new AlertElement();
    private readonly UserService _userService = new UserService();
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();
    
    [Test]
    public void Contact_ValidContacts_Success()
    {
        // Arrange
        var userMessage = new UserContacts(Config.Email, Config.Name, "bla-bla-bla");

        // Act
        _userService.LeaveMessage(userMessage);
        _loginAlert.IsAlertPresent();
        var alertMessage = _loginAlert.GetAlertText();
        _loginAlert.AlertAccept();
        
        // Assert
        Assert.That(alertMessage, Is.EqualTo("Thanks for the message!!"), 
            "Actual alert message isn't equal to expected.");
    }
}
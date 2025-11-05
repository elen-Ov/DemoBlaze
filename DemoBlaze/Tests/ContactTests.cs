using Allure.NUnit.Attributes;
using MyAllure = Allure.NUnit;
using DemoBlaze.Models;
using DemoBlaze.SeleniumFramework;
using DemoBlaze.Services;
using DemoBlaze.Utils;

namespace DemoBlaze.Tests;

[MyAllure.AllureNUnit]

public class ContactTests : BaseTest
{
    private readonly AlertElement _loginAlert = new AlertElement();
    private readonly UserService _userService = new UserService();
    
    [Test]
    [Category("Contact tests")]
    [Category("QA")]
    [AllureTag("smoke")]
    [AllureOwner("Elena Ov")]
    [AllureSuite("Ability to fill in the contact form check")]
    public void ContactForm_FillInContactFormWithValidData_Success()
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
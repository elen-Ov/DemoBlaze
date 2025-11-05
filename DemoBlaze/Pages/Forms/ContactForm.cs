using DemoBlaze.Models;
using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;
using Allure.NUnit.Attributes;

namespace DemoBlaze.Pages.Forms;

public class ContactForm
{
    private readonly By _contactEmailLocator = By.Id("recipient-email");
    private readonly By _contactNameLocator = By.Id("recipient-name");
    private readonly By _contactMessageLocator = By.Id("message-text");
    private readonly By _contactMessageButtonLocator = By.XPath("//button[text()='Send message']");
    
    private InputElement ContactEmailInput => new InputElement(_contactEmailLocator);
    private InputElement ContactNameInput => new InputElement(_contactNameLocator);
    private InputElement ContactMessageInput => new InputElement(_contactMessageLocator);
    private ButtonElement ContactButton => new ButtonElement(_contactMessageButtonLocator);
    
    [AllureStep("Отправка сообщения пользователя")]
    public void SendMessage(UserContacts contacts)
    {
        ContactEmailInput.SetUpText(contacts.ContactEmail);
        ContactNameInput.SetUpText(contacts.ContactName);
        ContactMessageInput.SetUpText(contacts.Message);
        ContactButton.ClickIfDisplayed();
    }
}
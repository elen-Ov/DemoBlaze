using DemoBlaze.Models;
using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;

namespace DemoBlaze.Pages.Forms;

public class ContactForm
{
    private readonly By _contactEmailLocator = By.Id("recipient-email");
    private readonly By _contactNameLocator = By.Id("recipient-name");
    private readonly By _contactMessageLocator = By.Id("message-text");
    private readonly By _contactMessageButtonLocator = By.XPath("//button[text()='Send message']");
    
    public InputElement ContactEmailInput => new InputElement(_contactEmailLocator);
    public InputElement ContactNameInput => new InputElement(_contactNameLocator);
    public InputElement ContactMessageInput => new InputElement(_contactMessageLocator);
    public ButtonElement ContactButton => new ButtonElement(_contactMessageButtonLocator);
    
    // подумать void или ContactForm
    public void SendMessage(UserContacts contacts)
    {
        ContactEmailInput.SetUpText(contacts.ContactEmail);
        ContactNameInput.SetUpText(contacts.ContactName);
        ContactMessageInput.SetUpText(contacts.Message);
        ContactButton.ClickIfDisplayed();
    }
}
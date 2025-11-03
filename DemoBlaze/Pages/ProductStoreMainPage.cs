using DemoBlaze.Pages.Forms;
using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;
using static System.String;

namespace DemoBlaze.Pages;

public class ProductStoreMainPage : BasePage
{
    private readonly By _contactLinkLocator = By.XPath("//a[text()='Contact']");
    private readonly By _cartLinkLocator = By.Id("cartur");
    private readonly By _logInLinkLocator = By.Id("login2");
    private readonly By _signUpLinkLocator = By.Id("signin2");
    private readonly By _welcomeMessageLocator = By.Id("nameofuser");
    private readonly By _categoriesLinkLocator = By.Id("cat");
    private readonly string _productLinkLocator = "//a[text()='{0}']"; // Nokia lumia 1520

    public bool IsMainPageOpen()
    {
        try
        {
            var label = new BaseElement(_categoriesLinkLocator);
            return label.IsDisplayed();
        }
        catch (WebDriverException ex) when 
            (ex is NoSuchElementException || 
             ex is StaleElementReferenceException)
        {
            return false;
        }
    }

    public void ChooseProduct(string productName)
    {
        var locator = new LinkElement(By.XPath(Format(_productLinkLocator, productName)));
        locator.ClickIfDisplayed();
    }
    public ContactForm OpenContactForm()
    {
        ClickContactLink();
        return new ContactForm();
    }
    
    public CartPage OpenCartPage()
    {
        ClickCartLink();
        return new CartPage();
    }
    
    public LogInForm OpenLoginForm()
    {
        ClickLoginLink();
        return new LogInForm();
    }

    public SignUpForm OpenSignUpForm()
    {
        ClickSignUpLink();
        return new SignUpForm();
    }
    
    private void ClickContactLink()
    {
        var contactLink = new LinkElement(_contactLinkLocator);
        contactLink.ClickIfDisplayed();
    }
    
    private void ClickCartLink()
    {
        var contactLink = new LinkElement(_cartLinkLocator);
        contactLink.ClickIfDisplayed();
    }
    private void ClickLoginLink()
    {
        var loginLink = new LinkElement(_logInLinkLocator);
        loginLink.ClickIfDisplayed();
    }
    
    private void ClickSignUpLink()
    {
        var signUpLink = new LinkElement(_signUpLinkLocator);
        signUpLink.ClickIfDisplayed();
    }
    
    public string GetWelcomeMessage()
    {
        var welcomeElement = new BaseElement(_welcomeMessageLocator);
        return welcomeElement.GetText();
    }
}
using DemoBlaze.Pages.Forms;
using DemoBlaze.SeleniumFramework;
using OpenQA.Selenium;
using static System.String;
using Allure.NUnit.Attributes;

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

    [AllureStep("Выбор товара по названию")]
    public void ChooseProduct(string productName)
    {
        var locator = new LinkElement(By.XPath(Format(_productLinkLocator, productName)));
        locator.ClickIfDisplayed();
    }
    
    [AllureStep("Открытие формы сообщения")]
    public ContactForm OpenContactForm()
    {
        ClickContactLink();
        return new ContactForm();
    }
    
    [AllureStep("Открытие страницы корзины")]
    public CartPage OpenCartPage()
    {
        ClickCartLink();
        return new CartPage();
    }
    
    [AllureStep("Открытие формы логина")]
    public LogInForm OpenLoginForm()
    {
        ClickLoginLink();
        return new LogInForm();
    }

    [AllureStep("Открытие формы регистрации")]
    public SignUpForm OpenSignUpForm()
    {
        ClickSignUpLink();
        return new SignUpForm();
    }
    
    [AllureStep("Клик по кнопке формы сообщения")]
    private void ClickContactLink()
    {
        var contactLink = new LinkElement(_contactLinkLocator);
        contactLink.ClickIfDisplayed();
    }
    
    [AllureStep("Клик по кнопке страницы корзины")]
    private void ClickCartLink()
    {
        var contactLink = new LinkElement(_cartLinkLocator);
        contactLink.ClickIfDisplayed();
    }
    
    [AllureStep("Клик по кнопке формы логина")]
    private void ClickLoginLink()
    {
        var loginLink = new LinkElement(_logInLinkLocator);
        loginLink.ClickIfDisplayed();
    }
    
    [AllureStep("Клик по кнопке формы регистрации")]
    private void ClickSignUpLink()
    {
        var signUpLink = new LinkElement(_signUpLinkLocator);
        signUpLink.ClickIfDisplayed();
    }
    
    [AllureStep("Получение приветствия!")]
    public string GetWelcomeMessage()
    {
        var welcomeElement = new BaseElement(_welcomeMessageLocator);
        return welcomeElement.GetText();
    }
}
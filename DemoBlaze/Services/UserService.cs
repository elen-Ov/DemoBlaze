using Allure.NUnit.Attributes;
using DemoBlaze.Models;
using DemoBlaze.Pages;

namespace DemoBlaze.Services;

public class UserService
{
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();

    [AllureStep("Регистрация пользователя")]
    public void Register(User user)
    {
        var signUpForm = _mainPage.OpenSignUpForm();
        signUpForm.SignUpUser(user);
    }

    [AllureStep("Логин пользователя")]
    public void Login(User user)
    {
        var loginForm = _mainPage.OpenLoginForm();
        loginForm.LoginUser(user);
    }
    
    [AllureStep("Отправка сообщения ")]
    public void LeaveMessage(UserContacts userContacts)
    {
        var contactForm = _mainPage.OpenContactForm();
        contactForm.SendMessage(userContacts);
    }
}
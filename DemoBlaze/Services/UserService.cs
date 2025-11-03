using DemoBlaze.Models;
using DemoBlaze.Pages;

namespace DemoBlaze.Services;

public class UserService // для регистрации, логина, сообщений
{
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();

    public void Register(User user)
    {
        var signUpForm = _mainPage.OpenSignUpForm();
        signUpForm.SignUpUser(user);
    }

    public void Login(User user)
    {
        var loginForm = _mainPage.OpenLoginForm();
        loginForm.LoginUser(user);
    }
    
    public void LeaveMessage(UserContacts userContacts)
    {
        var contactForm = _mainPage.OpenContactForm();
        contactForm.SendMessage(userContacts);
    }
}
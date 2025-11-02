using DemoBlaze.Builders;
using DemoBlaze.Pages;
using DemoBlaze.Pages.Forms;

namespace DemoBlaze.Tests;

public class SignUpTests : BaseTest
{
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();
    private readonly SignUpForm _signUpForm = new SignUpForm();

    [Test]
    public void SignUpTest()
    {
        _mainPage.ClickSignUpButton();
        var user = new UserBuilder()
            .WithUsername("user_test_559")
            .WithPassword("testpassword_559")
            .Build();
        _signUpForm.SignUpUser(user);
    }
}
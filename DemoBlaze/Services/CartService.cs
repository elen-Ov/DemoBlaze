using DemoBlaze.Pages;
using DemoBlaze.SeleniumFramework;
using Allure.NUnit.Attributes;

namespace DemoBlaze.Services;

public class CartService
{
    private readonly ProductStoreMainPage _mainPage = new ProductStoreMainPage();
    private readonly ProductPage _productPage = new ProductPage();
    private readonly CartPage _cartPage = new CartPage();
    
    [AllureStep("Наполнение корзины товарами")]
    public void AddProductsToCart(params string[] productNames)
    {
        foreach (var name in productNames)
        {
            _mainPage.ChooseProduct(name);
            _productPage.ClickAddToCartButton();
            var loginAlert = new AlertElement();
            loginAlert.AlertAccept();
            _productPage.GoToHomePage();
        }
    }
    
    [AllureStep("Получение состояния корзины")]
    public bool GetCartState()
    {
        _mainPage.OpenCartPage();
        var state = _cartPage.IsCartEmpty();
        _cartPage.GoToHomePage();
        return state;
    }
}
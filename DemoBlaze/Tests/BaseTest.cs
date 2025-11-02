using DemoBlaze.Pages;
using DemoBlaze.Utils;

namespace DemoBlaze.Tests;

public class BaseTest : BasePage
{
    [SetUp]
    public void Setup()
    {
        OpenProductStoreMainPage();
    }
    
    [TearDown]
    public void TearDown() 
    {
        BrowserUtils.CloseBrowser();
    }
}
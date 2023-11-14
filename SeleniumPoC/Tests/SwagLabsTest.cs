using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPoC.Configuration;
using SeleniumPoC.PageObject.Elements;

namespace SeleniumPoC.tests
{
    [TestFixture]
    public class SwagLabsTest
    {
        private IWebDriver driver;
        private SwagLabsElements swagLabsElements;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            BrowserManager.OpenUrl("https://www.saucedemo.com/", driver);
            swagLabsElements = new SwagLabsElements(driver);
        }

        [Test]
        public void PrimeiraCompra()
        {
            swagLabsElements.EnterUserName("standard_user");
            swagLabsElements.EnterPassword("secret_sauce");
            swagLabsElements.ClickLoginButton();
            swagLabsElements.SelectFirstProduct("1");
            swagLabsElements.AccessCartPage("29.99");
            swagLabsElements.CheckoutProduct();
            swagLabsElements.CompletePurchase("Nome", "Usuario", "323983", "32.39");
        }

        [TearDown]
        public void Teardown()
        {
            BrowserManager.CloseURL(driver);
        }
    }
}

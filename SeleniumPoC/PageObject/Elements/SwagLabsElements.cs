using OpenQA.Selenium;
using SeleniumPoC.Configuration;

namespace SeleniumPoC.PageObject.Elements
{
    public class SwagLabsElements
    {
        private IWebDriver driver;
        private BrowserManager browserManager;

        public SwagLabsElements(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement UserNameInput => driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        public IWebElement BackPackAddToCart => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public IWebElement RemoveButton => driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        public IWebElement AccessCart => driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
        public IWebElement CheckoutButton => driver.FindElement(By.Id("checkout"));
        public IWebElement FirstName => driver.FindElement(By.Id("first-name"));
        public IWebElement LastName => driver.FindElement(By.Id("last-name"));
        public IWebElement ZipPostalCode => driver.FindElement(By.Id("postal-code"));
        public IWebElement ContinueButton => driver.FindElement(By.Id("continue"));
        public IWebElement FinishButton => driver.FindElement(By.Id("finish"));
        public IWebElement InventoryItemName => driver.FindElement(By.XPath("//div[@class='inventory_item_name']"));
        public IWebElement CheckImage => driver.FindElement(By.XPath("//img[@alt='Pony Express']"));
        public IWebElement BackHomeButton => driver.FindElement(By.Id("back-to-products"));



        public void EnterUserName(string userName)
        {
            UserNameInput.Clear();
            UserNameInput.SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
            Assert.IsTrue(driver.Title.Equals("Swag Labs"));
        }
         public void SelectFirstProduct(string text)
        {
           
            BackPackAddToCart.Click();
            BrowserManager.ImplicitWait(10, driver);
            Assert.True(RemoveButton.Displayed);
        }

    }
}

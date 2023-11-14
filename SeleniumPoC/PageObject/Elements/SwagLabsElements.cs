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
        public IWebElement ShoppingCartBadge => driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']"));
        public IWebElement RemoveButton => driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        public IWebElement AccessCart => driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
        public IWebElement ProductPrice => driver.FindElement(By.XPath("//div[@class='inventory_item_price']"));
        public IWebElement CheckoutButton => driver.FindElement(By.Id("checkout"));
        public IWebElement CheckoutPageTitle => driver.FindElement(By.XPath("//span[@class='title']"));
        public IWebElement FirstName => driver.FindElement(By.Id("first-name"));
        public IWebElement LastName => driver.FindElement(By.Id("last-name"));
        public IWebElement ZipPostalCode => driver.FindElement(By.Id("postal-code"));
        public IWebElement ContinueButton => driver.FindElement(By.Id("continue"));
        public IWebElement TotalProductValue => driver.FindElement(By.XPath("//div[@class='summary_info_label summary_total_label']"));
        public IWebElement FinishButton => driver.FindElement(By.Id("finish"));
        public IWebElement CheckImage => driver.FindElement(By.XPath("//img[@alt='Pony Express']"));
        public IWebElement BackHomeButton => driver.FindElement(By.Id("back-to-products"));



        public void EnterUserName(string usuario)
        {
            UserNameInput.Clear();
            UserNameInput.SendKeys(usuario);
        }

        public void EnterPassword(string senha)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(senha);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
            Assert.IsTrue(driver.Title.Equals("Swag Labs"));
        }
        public void SelectFirstProduct(string qtd)
        {

            BackPackAddToCart.Click();
            ShoppingCartBadge.Text.Equals(qtd);
            BrowserManager.ImplicitWait(4, driver);
            Assert.True(RemoveButton.Displayed);
        }

        public void AccessCartPage(string preco)
        {
            AccessCart.Click();
            BrowserManager.ImplicitWait(4, driver);
            ProductPrice.Text.Equals(preco);
        }
        public void CheckoutProduct()
        {
            CheckoutButton.Click();
            CheckoutPageTitle.Text.Equals("Checkout: Your Information");
        }
        public void CompletePurchase(string nome, string sobrenome, string cep, string precototal)
        {
            FirstName.SendKeys(nome);
            LastName.SendKeys(sobrenome);
            ZipPostalCode.SendKeys(cep);
            ContinueButton.Click();
            BrowserManager.ImplicitWait(4, driver);
            TotalProductValue.Text.Equals(precototal);
            FinishButton.Click();
            Assert.IsNotNull(CheckImage, "Elemento não encontrado");
        }
    }
}

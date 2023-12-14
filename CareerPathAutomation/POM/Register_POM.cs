using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CareerPathAutomation
{
    public class RegisterUser_POM(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        //LOCATORS
        private IWebElement Registerhome => driver.FindElement(By.XPath("//div[@id='loginPanel']//a[text()='Register']"));
        private IWebElement Registerbutton => driver.FindElement(By.XPath("//input[@type='submit' and @class='button' and @value='Register']"));

        // SELECTOR
        public string link_register = "a[href=\"register.htm\"]";
        public string table_registerForm = "td[width=\"20%\"] input";
        public string btn_register = "input[value=\"Register\"]";
        public string span_errorMessage = "span[id=\"customer.username.errors\"]";

        // METHODS
        public void RegisterUser(bool loginError, By selector, string username, int usernumber)
        {
            if (loginError)
            {

                driver.FindElement(By.CssSelector(link_register)).Click();

                bool elementDisplayed;

                do
                {
                    var registerForm = driver.FindElements(By.CssSelector(table_registerForm));

                    foreach (IWebElement element in registerForm)
                    {
                        element.Clear();
                        element.SendKeys(username + usernumber);
                    }

                    driver.FindElement(By.CssSelector(btn_register)).Click();

                    try
                    {
                        elementDisplayed = driver.FindElement(selector).Displayed;
                    }

                    catch (NoSuchElementException)
                    {
                        elementDisplayed = false;
                    }

                    usernumber++;

                    Assert.That(username+usernumber, Is.LessThanOrEqualTo(username+5));

                } while (elementDisplayed);
            }
        }

        public void RegisterUserWithoutLogin(string username, int usernumber)
        {
            bool successMessageDisplayed;
            do
            {
                var registerForm = driver.FindElements(By.CssSelector(table_registerForm));

                foreach (IWebElement element in registerForm)
                {
                    element.Clear();
                    element.SendKeys(username + usernumber);
                }

                Registerbutton.Click();

                try
                {
                    WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));
                    //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='rightPanel']/h1[text()='Welcome " + username + usernumber + "']")));
                    successMessageDisplayed = true;
                }
                catch (WebDriverTimeoutException)
                {
                    // Timeout exception means the success message was not found
                    successMessageDisplayed = false;
                }

                usernumber++;

                Assert.That(username + usernumber, Is.LessThanOrEqualTo(username + 5));

            } while (!successMessageDisplayed);
        }

        public void NavigateToRegister()
        {
            Registerhome.Click();
        }

        public void ClickOnRegisterButton()
        {
            Registerbutton.Click();
        }

    }
}
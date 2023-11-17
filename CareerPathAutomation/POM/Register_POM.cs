using NUnit.Framework;
using OpenQA.Selenium;

namespace CareerPathAutomation
{
    public class RegisterUser_POM
    {
        private IWebDriver driver;

        public RegisterUser_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

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
    }
}
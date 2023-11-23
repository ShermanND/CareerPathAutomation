using OpenQA.Selenium;

namespace CareerPathAutomation.POM
{
    public class Login_POM
    {
        private IWebDriver driver;

        public Login_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        // SELECTOR
        public string input_username = "input[name=\"username\"]";
        public string input_password = "input[name=\"password\"]";
        public string button_login = "input[value=\"Log In\"]";
        public string p_errorMessage = "p[class=\"error\"]";

        // LOCATOR
        private IWebElement Username => driver.FindElement(By.CssSelector(input_username));
        private IWebElement Password => driver.FindElement(By.CssSelector(input_password));
        private IWebElement loginButton => driver.FindElement(By.CssSelector(button_login));

        // METHODS
        public void LoginUser(string username, int usernumber)
        {
            Username.SendKeys(username + usernumber);
            Password.SendKeys(username + usernumber);
            loginButton.Click();
        }

        public Boolean GetElementIsDisplayed(By selector)
        {
            Boolean elementDisplayed;

            try
            {
                elementDisplayed = driver.FindElement(selector).Displayed;
            }

            catch (NoSuchElementException)
            {
                elementDisplayed = false;
            }

            return elementDisplayed;
        }
    }
}
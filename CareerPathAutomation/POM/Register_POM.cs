using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace CareerPathAutomation
{
    public class RegisterUser_POM
    {
        private IWebDriver driver;
        public RegisterUser_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //LOCATORS
        private IWebElement registerhome => driver.FindElement(By.XPath("//div[@id='loginPanel']//a[text()='Register']"));
        private IWebElement registerbutton => driver.FindElement(By.XPath("//input[@type='submit' and @class='button' and @value='Register']"));

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

        public void registerUserWithoutLogin(string username, int usernumber)
        {
            bool successMessageDisplayed = false;

            do
            {
                var registerForm = driver.FindElements(By.CssSelector(table_registerForm));

                foreach (IWebElement element in registerForm)
                {
                    element.Clear();
                    element.SendKeys(username + usernumber);
                }

                registerbutton.Click();

                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='rightPanel']/h1[text()='Welcome " + username + usernumber + "']")));
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
            registerhome.Click();
        }

        public void clickOnRegisterButton()
        {
            registerbutton.Click();
        }

    }
}
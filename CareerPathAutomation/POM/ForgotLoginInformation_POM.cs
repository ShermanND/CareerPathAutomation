using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPathAutomation.POM
{
    public class ForgotLoginInformation_POM
    {
        private IWebDriver driver;
        public ForgotLoginInformation_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //locators
        IWebElement forgotButton => driver.FindElement(By.XPath("//a[contains(text(), 'Forgot login info?')]"));

        IWebElement findMyLoginInfo => driver.FindElement(By.XPath("//input[@value='Find My Login Info']"));

        IWebElement clickOnLoginInfoScreen => driver.FindElement(By.XPath("//form[@id='lookupForm']//input[@type='submit' and @class='button' and @value='Find My Login Info']"));

        IWebElement clicktable => driver.FindElement(By.XPath("//*[@id=\"lookupForm\"]/table"));

        //selectors
        public string table = "form#lookupForm > .form2";
        
        //methods
        public void clickonforgotButton()
        {
            forgotButton.Click();
        }
        
        public void clickonfindMyLoginInfo()
        {
            findMyLoginInfo.Click();
        }

        public void clickOnLoginInfoS()
        {
            clickOnLoginInfoScreen.Click();
        }

        public void completefields(string username, int usernumber)
        {
           
                bool successMessageDisplayed = false;

                do
                {
                    IReadOnlyCollection<IWebElement> textInputFields = driver.FindElements(By.XPath("//*[@id='lookupForm']//input[@type='text']"));

                    foreach (IWebElement inputField in textInputFields)
                    {
                        // Limpia y envía teclas solo si es un campo de entrada de texto
                        inputField.Clear();
                        inputField.SendKeys(username + usernumber);
                    }

                    clickOnLoginInfoS();


                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='rightPanel']/p[1]")));
                    successMessageDisplayed = true;
                }
                catch (WebDriverTimeoutException)
                {
                    // Timeout exception means the element was not found
                    successMessageDisplayed = false;
                }

                } while (!successMessageDisplayed);
            
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CareerPathAutomation.POM
{
    public class ForgotLoginInformation_POM(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        //locators
        IWebElement ForgotButton => driver.FindElement(By.XPath("//a[contains(text(), 'Forgot login info?')]"));

        IWebElement FindMyLoginInfo => driver.FindElement(By.XPath("//input[@value='Find My Login Info']"));

        IWebElement ClickOnLoginInfoScreen => driver.FindElement(By.XPath("//form[@id='lookupForm']//input[@type='submit' and @class='button' and @value='Find My Login Info']"));

        //selectors
        public string table = "form#lookupForm > .form2";
        
        //methods
        public void ClickonforgotButton()
        {
            ForgotButton.Click();
        }
        
        public void ClickonfindMyLoginInfo()
        {
            FindMyLoginInfo.Click();
        }

        public void ClickOnLoginInfoS()
        {
            ClickOnLoginInfoScreen.Click();
        }

        public void Completefields(string username, int usernumber)
        {

            bool successMessageDisplayed;
            do
                {
                    IReadOnlyCollection<IWebElement> textInputFields = driver.FindElements(By.XPath("//*[@id='lookupForm']//input[@type='text']"));

                    foreach (IWebElement inputField in textInputFields)
                    {
                        // Limpia y envía teclas solo si es un campo de entrada de texto
                        inputField.Clear();
                        inputField.SendKeys(username + usernumber);
                    }

                    ClickOnLoginInfoS();


                try
                {
                    WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));
                    //wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='rightPanel']/p[1]")));
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

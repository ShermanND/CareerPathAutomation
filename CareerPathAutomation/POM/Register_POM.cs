using NUnit.Framework;
using OpenQA.Selenium;
using System;

public class RegisterUser_POM
{
    private IWebDriver driver;

    public RegisterUser_POM(IWebDriver driver)
    {
        this.driver = driver;
    }

    // SELECTOR
    public string link_register = "//a[text()=\"Register\"]";
    public string table_registerForm = "td[width=\"20%\"] input";
    public string btn_register = "input[value=\"Register\"]";

    // USER DATA
    public string userCredential = "user3";

    public void RegisterUser(Boolean loginError)
    {
        if (loginError == true)
        {
            driver.FindElement(By.XPath(link_register)).Click();

            var registerForm = driver.FindElements(By.CssSelector(table_registerForm));

            foreach (IWebElement element in registerForm)
            {
                element.SendKeys(userCredential);
            }

            driver.FindElement(By.CssSelector(btn_register)).Click();
        }

        
    }
}
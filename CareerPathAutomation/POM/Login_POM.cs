using OpenQA.Selenium;
using System;

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
    private IWebElement loginButton => driver.FindElement(By.CssSelector(button_login));

    // CREDENTIALS
    public string username = "user1";
    public string password = "user1";

    public void LoginUser(By Username, By Password)
    {
        driver.FindElement(Username).SendKeys(username);
        driver.FindElement(Password).SendKeys(password);
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
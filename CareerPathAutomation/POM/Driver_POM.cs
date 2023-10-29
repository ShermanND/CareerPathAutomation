using OpenQA.Selenium;

public class Driver_POM
{
    private IWebDriver driver;

    public Driver_POM(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void DriverSetUp()
    {
        driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        driver.Manage().Window.FullScreen();
    }
}
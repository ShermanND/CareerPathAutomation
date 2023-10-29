using NUnit.Framework;
using OpenQA.Selenium;
using System;

public class HomeLatestNews_POM
{
    private IWebDriver driver;

    public HomeLatestNews_POM(IWebDriver driver)
    {
        this.driver = driver;
    }

    // SELECTORS
    public string link_reOpened = "//a[text()=\"ParaBank Is Now Re-Opened\"]";
    public string link_billPay = "//a[text()=\"New! Online Bill Pay\"]";
    public string link_accountTransfers = "//a[text()=\"New! Online Account Transfers\"]";

    // SCREEN TITLE
    public string title_news = "ParaBank | News";

    public void ClickOnLink(By selector)
    {
        IWebElement link = driver.FindElement(selector);
        link.Click();
    }

    public void AssertTitle(string screenTitle)
    {
        string driverTitle = driver.Title;
        Assert.That(driverTitle, Is.EqualTo(screenTitle));
    }

    public void VerifyElementIsDisplayed(By selector)
    {
        Boolean isDiplayed = driver.FindElement(selector).Displayed;
        Assert.IsTrue(isDiplayed);
    }

}
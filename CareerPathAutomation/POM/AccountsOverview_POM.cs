using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;
using System.Reflection.Emit;

public class AccountsOverview_POM
{
    private IWebDriver driver;

    public AccountsOverview_POM(IWebDriver driver)
    {
        this.driver = driver;
    }

    // SELECTORS
    public string h1_accountsOverview = "h1[class=\"title\"]";
    public string h1_accountActivity = "div[ng-if=\"showActivity\"] h1";

    public string link_accountsOverview = "a[href=\"/parabank/overview.htm\"]";
    public string link_accountNumber = "tr[ng-repeat=\"account in accounts\"] a";

    public string label_account = "//th[text()=\"Account\"]";
    public string label_balance = "//th[text()=\"Balance*\"]";
    public string label_availableamount = "//th[text()=\"Available Amount\"]";
    public string label_note = "td[colspan=\"3\"]";
    public string label_total = "//b[text()=\"Total\"]";

    public string td_balance = "tr[ng-repeat=\"account in accounts\"] td:nth-child(2)";
    public string td_availableamount = "tr[ng-repeat=\"account in accounts\"] td:nth-child(3)";
    public string b_totalamount = "td b[class=\"ng-binding\"]";

    public string table_columns = "table[id=\"accountTable\"] th";

    // LOCATORS
    private IWebElement accountsOverviewLink => driver.FindElement(By.CssSelector(link_accountsOverview));

    // ELEMENT TEXT
    public string footnote = "*Balance includes deposits that may be subject to holds";
    public string title_accountsOverview = "Accounts Overview";
    public string title_accountActivity = "Account Activity";

    // LIST
    public List<string> columnName = new List<string> { "Account", "Balance*", "Available Amount" };

    // METHODS
    public void NavigateToAccountsOverview()
    {
        accountsOverviewLink.Click();
    }

    public void VerifyElementIsDisplayed(By selector)
    {
        Boolean elementDisplayed = driver.FindElement(selector).Displayed;
        Assert.IsTrue(elementDisplayed);
    }

    public void VerifyElementsLabels(By selector, List<string> columnName)
    {
        var tableColumns = driver.FindElements(selector);
        List<string> columnname = new List<string>();

        foreach (IWebElement column in tableColumns)
        {
            string name = column.Text;
            columnname.Add(name);
        }

        Assert.That(columnname, Is.EqualTo(columnName));
    }


    public void VerifyElementText(By selector, string Text)
    {
        string text = driver.FindElement(selector).Text;
        Assert.That(text, Is.EqualTo(Text));
    }

    public void ClickElement(By selector)
    {
        driver.FindElement(selector).Click();
    }
}
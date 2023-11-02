using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;

namespace CareerPathAutomation
{
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

        public string table_labels = "table[id=\"accountTable\"] th";

        // LOCATORS
        private IWebElement accountsOverviewLink => driver.FindElement(By.CssSelector(link_accountsOverview));

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

        public void VerifyElementsLabels(By selector, string[] labels)
        {
            var driverLabels = driver.FindElements(selector);
            List<string> elementLabels = new List<string>();

            foreach (IWebElement label in driverLabels)
            {
                string name = label.Text;
                elementLabels.Add(name);
            }

            string[] Labels = elementLabels.ToArray();

            Assert.That(Labels, Is.EqualTo(labels));
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
}
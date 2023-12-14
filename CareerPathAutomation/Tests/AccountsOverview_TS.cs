using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CareerPathAutomation
{
    [TestFixture]
    public class AccountsOverview
    {
        private IWebDriver driver;
        private AccountsOverview_POM accountsoverviewpom;


        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize driver setup
            driver = new ChromeDriver();
            Driver driverSetup = new(driver);
            driverSetup.DriverSetUp();

            // Login user
            Login_POM loginpom = new(driver);
            Credentials credentials = new();
            loginpom.LoginUser(credentials.username, credentials.usernumber);

            // Verify login error message is true
            bool loginError = loginpom.GetElementIsDisplayed(By.CssSelector(loginpom.p_errorMessage));

            // Register user if loginError is true
            RegisterUser_POM registeruserpom = new(driver);
            registeruserpom.RegisterUser(loginError, By.CssSelector(registeruserpom.span_errorMessage), credentials.username, credentials.usernumber);

            // Navigate to Accounts Overview screen
            accountsoverviewpom = new AccountsOverview_POM(driver);
            accountsoverviewpom.NavigateToAccountsOverview();

            Thread.Sleep(3000);
        }

        [Test, Order(1)]
        [Category("Accounts Overview | Accounts Overview screen title is visible")]
        public void Test01()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Accounts Overview screen
            // Then I verify that Accounts Overview screen title is visible
            accountsoverviewpom.VerifyElementIsDisplayed(By.CssSelector(accountsoverviewpom.h1_accountsOverview));
        }

        [Test, Order(2)]
        [Category("Accounts Overview | Screen title is Accounts Overview")]
        public void Test0202()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Accounts Overview screen
            // Then I verify that Screen title is Accounts Overview
            Titles titles = new();
            accountsoverviewpom.VerifyElementText(By.CssSelector(accountsoverviewpom.h1_accountsOverview), titles.accountsOverview);
        }

        [Test, Order(3)]
        [Category("Accounts Overview | Account, Balance & Available Amount are displayed as labels")]
        public void Test0203()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Accounts Overview screen
            // Then I verify that Account, Balance & Available Amount are displayed as labels
            Labels labels = new();
            accountsoverviewpom.VerifyElementsLabels(By.CssSelector(accountsoverviewpom.table_labels), labels.accountsOverview);
        }

        [Test, Order(4)]
        [Category("Accounts Overview | Account column displays the account number")]
        public void Test0204()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Accounts Overview screen
            // Then I verify that Account column displays the account number
            accountsoverviewpom.VerifyElementIsDisplayed(By.CssSelector(accountsoverviewpom.link_accountNumber));
        }

        [Test, Order(5)]
        [Category("Accounts Overview | Account number redirects to Account Activity screen")]
        public void Test0205()
        {
            // Given I have accessed to Parabank website
            // And I have navigated to Accounts Overview screen
            // When I click on the account number
            accountsoverviewpom.ClickElement(By.CssSelector(accountsoverviewpom.link_accountNumber));

            // Then I verify that Account number redirects to Account Activity screen
            Titles titles = new();
            accountsoverviewpom.VerifyElementText(By.CssSelector(accountsoverviewpom.h1_accountActivity), titles.accountActivity);
            driver.Navigate().Back();
        }

        [Test, Order(6)]
        [Category("Accounts Overview | Balance column displays the balance amount")]
        public void Test0206()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Accounts Overview screen
            // Then I verify that Balance column displays the balance amount
            accountsoverviewpom.VerifyElementIsDisplayed(By.CssSelector(accountsoverviewpom.td_balance));
        }

        [Test, Order(7)]
        [Category("Accounts Overview | Available Amount displays the available amount")]
        public void Test0207()
        {
            //	Given I have accessed to Parabank website
            // When I navigate to Accounts Overview screen
            // Then I verify that Available Amount displays the available amount
            accountsoverviewpom.VerifyElementIsDisplayed(By.CssSelector(accountsoverviewpom.td_availableamount));
        }

        [Test, Order(8)]
        [Category("Accounts Overview | Total displays the total amount")]
        public void Test0208()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Accounts Overview screen
            // Then I verify that Total column displays the total amount
            accountsoverviewpom.VerifyElementIsDisplayed(By.CssSelector(accountsoverviewpom.b_totalamount));
        }

        [Test, Order(9)]
        [Category("Accounts Overview | 'Balance includes deposits that may be subject to holds' footnote is visible")]
        public void Test0209()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Accounts Overview screen
            // Then I verify that 'Balance includes deposits that may be subject to holds' footnote is visible
            accountsoverviewpom.VerifyElementIsDisplayed(By.CssSelector(accountsoverviewpom.label_note));
        }

        [Test, Order(10)]
        [Category("Accounts Overview | Footnote text is: Balance includes deposits that may be subject to holds")]
        public void Test0210()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Accounts Overview screen
            // Then I verify that the Footnote text is: Balance includes deposits that may be subject to holds
            Messages messages = new();
            accountsoverviewpom.VerifyElementText(By.CssSelector(accountsoverviewpom.label_note), messages.footnote);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
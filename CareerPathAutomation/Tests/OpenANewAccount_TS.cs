using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerPathAutomation.POM;

namespace CareerPathAutomation.Tests
{
    public class OpenANewAccount_TS
    {
        private IWebDriver driver;
        private OpenANewAccount_POM newaccountpom;
        private Titles titles;

        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize driver setup
            driver = new ChromeDriver();
            Driver driverSetup = new Driver(driver);
            driverSetup.DriverSetUp();
            titles = new Titles();

            // Login user
            Login_POM loginpom = new Login_POM(driver);
            Credentials credentials = new Credentials();
            loginpom.LoginUser(credentials.username, credentials.usernumber);

            // Verify login error message is true
            Boolean loginError = loginpom.GetElementIsDisplayed(By.CssSelector(loginpom.p_errorMessage));

            // Register user if loginError is true
            RegisterUser_POM registeruserpom = new RegisterUser_POM(driver);
            registeruserpom.RegisterUser(loginError, By.CssSelector(registeruserpom.span_errorMessage), credentials.username, credentials.usernumber);

            //Navigate to open a new account
            newaccountpom = new OpenANewAccount_POM(driver);
            newaccountpom.NavigateToOpenANewAccount();


        }

        
        [Test, Order(1)]
        [Category("Open a New Account | Open a new account title")]
        public void Test01()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Open a New account screen
            // Then I verify that Open a new account screen title is visible
            string title = driver.Title;
            Assert.AreEqual(titles.newaccount, title);

        }

        [Test, Order(2)]
        [Category("Open a New Account | Open a new checking account")]
        public void Test02()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Open a new account screen
            // Then I create a new checking account
            newaccountpom.CrearNuevaCuenta();
            

        }

        [Test, Order(3)]
        [Category("Open a New Account | Verify account created title")]
        public void Test03()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Open a new account screen
            // Then I create a new checking account and verify account created title
            string title = driver.Title;
            Assert.AreEqual(titles.newaccountcreated, title);


        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPathAutomation.Tests
{
    public class Login_TS
    {
        private IWebDriver driver;
        private Login_POM login;
        private Credentials credentials;
        private Titles titles;

        [OneTimeSetUp]

        public void Setup()
        {
            // Initialize driver setup
            driver = new ChromeDriver();
            Driver driverSetup = new Driver(driver);
            driverSetup.DriverSetUp();

            // Initialize login
            login = new Login_POM(driver);
            credentials = new Credentials();
            titles = new Titles();

        }
     
       

        [Test(), Order(1)]
        [Category("Customer Login | Home Screen login")]
        public void test01()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen and input credentials into customer login
            login.LoginUser(credentials.username, credentials.usernumber);


            // Verify login error message is not true
            Boolean loginError = login.GetElementIsDisplayed(By.CssSelector(login.p_errorMessage));

            //Then I verify that welcome screen is display as screen
            string title = driver.Title;
            Assert.AreEqual(titles.accounts, title);

            driver.Navigate().Back();

        }

        [Test(), Order(2)]
        [Category("Customer Login | Error not register")]
        public void test02()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen and input credentials into customer login
            login.LoginUser(credentials.invalidUsername, credentials.invalidUserNumber);

            // Verify login error message is true
            Boolean loginError = login.GetElementIsDisplayed(By.CssSelector(login.p_errorMessage));

            //verify error message is display
            string title = driver.Title;
            Assert.AreEqual(titles.loginError, title);
        }

        /*
        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
        }
        */
    }
}

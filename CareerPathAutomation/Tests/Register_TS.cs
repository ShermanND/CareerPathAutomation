using CareerPathAutomation.POM;
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
    public class Register_TS
    {
        private IWebDriver driver;
        private RegisterUser_POM registerpom;
        private Titles titles;
        private Credentials credentials;

        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize driver setup
            driver = new ChromeDriver();
            Driver driverSetup = new Driver(driver);
            driverSetup.DriverSetUp();
            titles = new Titles();
            credentials = new Credentials();

            //Navigate to register screen
            registerpom = new RegisterUser_POM(driver);
            registerpom.NavigateToRegister();



        }

        [Test, Order(1)]
        [Category("Register | Register user title")]
        public void Test01()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Register screen
            // Then I verify that Register screen title is visible
            string title = driver.Title;
            Assert.AreEqual(titles.register, title);

        }

        [Test, Order(2)]
        [Category("Register | Register user")]
        public void Test02()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Register screen
            // Then I create the user
            registerpom.registerUserWithoutLogin(credentials.username,credentials.usernumber);


        }

        [Test, Order(3)]
        [Category("Register | Register user screen")]
        public void Test03()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Register screen
            // Then I verify that Register screen title is visible after I Register the user
            string title = driver.Title;
            Assert.AreEqual(titles.welcomeRegister, title);


        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }

   }


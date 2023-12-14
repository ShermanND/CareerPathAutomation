﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CareerPathAutomation
{
    [TestFixture]
    public class HomeMenu
    {
        IWebDriver driver;
        HomeMenu_POM homemenu;
        Titles titles;

        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize driver setup
            driver = new ChromeDriver();
            Driver driverSetup = new(driver);
            driverSetup.DriverSetUp();

            // Initialize homemenu and titles objects
            homemenu = new HomeMenu_POM(driver);
            titles = new Titles();
        }
        [Test(), Order(1)]
        [Category("Home screen | Home screen button")]
        public void Test01()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            homemenu.clickonHomeScreen();

            //Then I verify that home screen is display as screen
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.home));
        }

        [Test(), Order(2)]
        [Category("Home screen | Home screen customer care")]
        public void Test02()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            homemenu.clickonCustomerCare();

            //Then I verify that customer care is displayed as screen
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.customerCare));
        }
        [Test(), Order(3)]
        [Category("Home Screen | Open About Us")]
        public void Test03()
        {
            // Given I have accessed to Parabank website
            // When I navigate to About Us screen
            homemenu.clickonAboutUs();

            // Then I verify that About Us is displayed as screen title
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.aboutUs));
        }

        [Test(), Order(4)]
        [Category("Home Screen | Open Products")]
        public void Test04()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Products screen
            homemenu.clickonProduct();

            // Then I verify that "Automated Software Testing Tool Suite | Parasoft" is displayed as screen title
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.products));
        }

        [Test(), Order(5)]
        [Category("Home Screen | Open Locations")]
        public void Test05()
        {
            // Given I have accessed to Parabank website
            driver.Navigate().Back();

            // When I navigate to Locations screen
            homemenu.clickonLocations();

            // Then I verify that "Automated Software Testing Solutions For Every Testing Need" is displayed as screen title
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.locations));
        }        
  
        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Dispose();
        }
    }
}
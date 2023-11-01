using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


namespace CareerPathAutomation
{
    [TestFixture]
    public class HomeMenu_TS
    {
        IWebDriver driver = new ChromeDriver();
        const string TITLE_ABOUT_US = "ParaBank | About Us";
        const string TITLE_PRODUCTS = "Automated Software Testing Tool Suite | Parasoft";
        const string TITLE_LOCATIONS = "Automated Software Testing Solutions For Every Testing Need";

        [OneTimeSetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            driver.Manage().Window.FullScreen();
        }
        [Test (), Order(1)]
        [Category("Home Screen | Open About Us")]
        public void Test01() {
            Homemenu_TS homemenu_TS = new Homemenu_TS(driver);
            homemenu_TS.clickonAboutUs();
            string title = driver.Title;
            Assert.AreEqual(TITLE_ABOUT_US, title);
        }

        [Test(), Order(2)]
        [Category("Home Screen | Open Products")]
        public void test02()
        {
            HomeMenu_TS homemenu_TS = new HomeMenu_TS(driver);
            homemenu_TS.clickonProduct();
            string title = driver.Title;
            Assert.AreEqual(TITLE_PRODUCTS, title);
        }

        [Test(), Order(3)]
        [Category("Home Screen | Open Locations")]
        public void test03()
        {
            HomeMenu_TS homemenu_TS = new HomeMenu_TS(driver);
            driver.Navigate().Back();
            homemenu_TS.clickonLocations();
            string title = driver.Title;
            Assert.AreEqual(TITLE_LOCATIONS, title);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
        }


    }
}

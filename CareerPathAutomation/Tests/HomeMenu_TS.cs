using NUnit.Framework;
using OpenQA.Selenium;
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
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            driver.Manage().Window.FullScreen();

            // Initialize homemenu and titles objects
            homemenu = new HomeMenu_POM(driver);
            titles = new Titles();
        }
        [Test(), Order(1)]
        [Category("Home Screen | Open About Us")]
        public void Test01()
        {
            // Given I have accessed to Parabank website
            // When I navigate to About Us screen
            homemenu.clickonAboutUs();

            // Then I verify that About Us is displayed as screen title
            string title = driver.Title;
            Assert.AreEqual(titles.aboutUs, title);
        }

        [Test(), Order(2)]
        [Category("Home Screen | Open Products")]
        public void test02()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Products screen
            homemenu.clickonProduct();

            // Then I verify that "Automated Software Testing Tool Suite | Parasoft" is displayed as screen title
            string title = driver.Title;
            Assert.AreEqual(titles.products, title);
        }

        [Test(), Order(3)]
        [Category("Home Screen | Open Locations")]
        public void test03()
        {
            // Given I have accessed to Parabank website
            driver.Navigate().Back();

            // When I navigate to Locations screen
            homemenu.clickonLocations();

            // Then I verify that "Automated Software Testing Solutions For Every Testing Need" is displayed as screen title
            string title = driver.Title;
            Assert.AreEqual(titles.locations, title);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
        }


    }
}
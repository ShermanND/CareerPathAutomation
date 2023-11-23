using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using CareerPathAutomation.Data;
using CareerPathAutomation.POM;
using CareerPathAutomation.SetUp;

namespace CareerPathAutomation.Tests
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
            Driver driverSetup = new Driver(driver);
            driverSetup.DriverSetUp();

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
            Assert.That(title, Is.EqualTo(titles.aboutUs));
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
            Assert.That(title, Is.EqualTo(titles.products));
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
            Assert.That(title, Is.EqualTo(titles.locations));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Dispose();
        }


    }
}
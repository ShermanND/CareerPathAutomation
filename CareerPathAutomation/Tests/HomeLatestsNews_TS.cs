using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using CareerPathAutomation.Data;
using CareerPathAutomation.POM;
using CareerPathAutomation.SetUp;

namespace CareerPathAutomation.Tests
{
    [TestFixture]
    public class HomeLatestNews
    {
        private IWebDriver driver;
        private HomeLatestNews_POM homelatestnewspom;

        [OneTimeSetUp]
        public void Setup()
        {

            // Initialize driver setup
            driver = new ChromeDriver();
            Driver driverpom = new Driver(driver);
            driverpom.DriverSetUp();

            // Initialize HomeLatestNews objects
            homelatestnewspom = new HomeLatestNews_POM(driver);

            Thread.Sleep(3000);
        }

        [Test, Order(1)]
        [Category("Home Latest News | Parabank Is Now Re-Opened link is visible")]
        public void Test0101()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that Parabank Is Now Re-Opened link is visible
            homelatestnewspom.VerifyElementIsDisplayed(By.XPath(homelatestnewspom.link_reOpened));
        }

        [Test, Order(2)]
        [Category("Home Latest News | Parabank Is Now Re-Opened link redirects to News screen")]
        public void Test0102()
        {
            // Given I have accessed to Parabank website
            // And I have located Parabank Is Now Re-Opened link            
            // When I click on the link
            homelatestnewspom.ClickOnLink(By.XPath(homelatestnewspom.link_reOpened));

            // Then I verify that Parabank Is Now Re-Opened link redirects to News screen
            Titles titles = new Titles();
            homelatestnewspom.AssertTitle(By.CssSelector(homelatestnewspom.h1_title), titles.parabankNews);
        }

        [Test, Order(3)]
        [Category("Home Latest News | New Online Bill Pay link is visible")]
        public void Test0103()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that New Online Bill Pay link is visible
            homelatestnewspom.VerifyElementIsDisplayed(By.XPath(homelatestnewspom.link_billPay));

        }

        [Test, Order(4)]
        [Category("Home Latest News | New Online Bill Pay link redirects to News screen")]
        public void Test0104()
        {
            // Given I have accessed to Parabank website
            // And I have located New Online Bill Pay link            
            // When I click on the link
            homelatestnewspom.ClickOnLink(By.XPath(homelatestnewspom.link_billPay));

            // Then I verify that New Online Bill Pay link redirects to News screen
            Titles titles = new Titles();
            homelatestnewspom.AssertTitle(By.CssSelector(homelatestnewspom.h1_title), titles.parabankNews);
        }

        [Test, Order(5)]
        [Category("Home Latest News | New Online Account Transfers link is visible")]
        public void Test0105()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that New Online Account Transfers link is visible
            homelatestnewspom.VerifyElementIsDisplayed(By.XPath(homelatestnewspom.link_accountTransfers));

        }

        [Test, Order(6)]
        [Category("Home Latest News | New Online Account Transfers link redirects to News screen")]
        public void Test0106()
        {
            // Given I have accessed to Parabank website
            // And I have located New Online Account Transfers link            
            // When I click on the link
            homelatestnewspom.ClickOnLink(By.XPath(homelatestnewspom.link_accountTransfers));

            // Then I verify that New Online Account Transfers link redirects to News screen
            Titles titles = new Titles();
            homelatestnewspom.AssertTitle(By.CssSelector(homelatestnewspom.h1_title), titles.parabankNews);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}

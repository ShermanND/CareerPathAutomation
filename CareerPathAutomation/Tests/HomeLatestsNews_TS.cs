using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace CareerPathAutomation
{
    [TestFixture]
    public class HomeLatestNews
    {
        IWebDriver driver;
        HomeLatestNews_POM homelatestnewspom;

        static void Main() { }

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            Driver_POM driverpom = new Driver_POM(driver);
            driverpom.DriverSetUp();

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
            homelatestnewspom.AssertTitle(homelatestnewspom.title_news);
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
            homelatestnewspom.AssertTitle(homelatestnewspom.title_news);
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
            homelatestnewspom.AssertTitle(homelatestnewspom.title_news);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
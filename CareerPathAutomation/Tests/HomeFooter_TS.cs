using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace CareerPathAutomation
{
    [TestFixture]
    public class HomeFooter
	{
        IWebDriver driver;
        HomeFooter_POM homefooterpom;

       // static void Main() { }

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            Driver driverpom = new Driver(driver);
            driverpom.DriverSetUp();
            homefooterpom = new HomeFooter_POM(driver);
            Thread.Sleep(3000);
        }

        [Test, Order(1)]
        [Category("Test Case 71: Accessing Home Footer")]
        public void Test0101()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that Home in the Footer is working
            homefooterpom.NavigateAnywhere(homefooterpom.homeFooter);
            string title = driver.Title;
            //assert
            Assert.AreEqual(homefooterpom.titleHome, title);
        }

        [Test, Order(2)]
        [Category("Test Case 72: Accesing About Us Footer")]
        public void Test0102()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that About Us in the Footer is working
            homefooterpom.NavigateAnywhere(homefooterpom.aboutUsFooter);
            string title = driver.Title;
            Assert.AreEqual(homefooterpom.titleAboutUs, title);
        }

        [Test, Order(3)]
        [Category("Test Case 73: Accessing Services Footer")]
        public void Test0103()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that Services in the Footer is working
            homefooterpom.NavigateAnywhere(homefooterpom.servicesFooter);
            string title = driver.Title;
            Assert.AreEqual(homefooterpom.titleServices, title);
        }

        [Test, Order(4)]
        [Category("Test Case 74: Accessing Products Footer")]
        public void Test0104()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that Products in the Footer is working
            homefooterpom.NavigateAnywhere(homefooterpom.productsFooter);
            driver.Navigate().Back();
            string title = driver.Title;
            Assert.AreEqual(homefooterpom.titleServices, title);
        }

        [Test, Order(5)]
        [Category("Test Case 75: Accessing Locations Footer")]
        public void Test0105()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that Locations in the Footer is working
            homefooterpom.NavigateAnywhere(homefooterpom.locationsFooter);
            driver.Navigate().Back();
            string title = driver.Title;
            Assert.AreEqual(homefooterpom.titleServices, title);
        }

        [Test, Order(6)]
        [Category("Test Case 76: Accesing Forum Footer")]
        public void Test0106()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that Forum in the Footer is working
            homefooterpom.NavigateAnywhere(homefooterpom.forumFooter);
            driver.Navigate().Back();
            string title = driver.Title;
            Assert.AreEqual(homefooterpom.titleServices, title);
        }

        [Test, Order(7)]
        [Category("Test Case 77: Accessing Site Map Footer")]
        public void Test0107()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that Site Map in the Footer is working
            homefooterpom.NavigateAnywhere(homefooterpom.siteMapFooter);
            string title = driver.Title;
            Assert.AreEqual(homefooterpom.titleSiteMap, title);
        }

        [Test, Order(8)]
        [Category("Test Case 79: Accesing \"Contact Us\" Footer")]
        public void Test0108()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that Contact Us in the Footer is working
            homefooterpom.NavigateAnywhere(homefooterpom.contactUsFooter);
            string title = driver.Title;
            Assert.AreEqual(homefooterpom.titleCustomerCare, title);
        }

        [Test, Order(9)]
        [Category("Test Case 80: Visiting ParaSoft")]
        public void Test0109()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that the ParaSoft Link below the Footer is working
            homefooterpom.NavigateAnywhere(homefooterpom.parasoftLink);
            string title = driver.Title;
            Assert.AreEqual(homefooterpom.titleCustomerCare, title);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
        }


    }
}

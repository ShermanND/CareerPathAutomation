using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using CareerPathAutomation.POM;

namespace CareerPathAutomation.Tests
{
    public class ForgotLoginInformation_TS
    {
        private IWebDriver driver;
        private ForgotLoginInformation_POM forgotlogin;
        private Credentials credentials;
        private Titles titles;

        [OneTimeSetUp]

        public void Setup()
        {
            // Initialize driver setup
            driver = new ChromeDriver();
            Driver driverSetup = new(driver);
            driverSetup.DriverSetUp();

            // Initialize login
            forgotlogin = new ForgotLoginInformation_POM(driver);
            credentials = new Credentials();
            titles = new Titles();

            // Login user
            Login_POM loginpom = new(driver);
            credentials = new Credentials();
            loginpom.LoginUser(credentials.username, credentials.usernumber);

            // Verify login error message is true
            bool loginError = loginpom.GetElementIsDisplayed(By.CssSelector(loginpom.p_errorMessage));

            // Register user if loginError is true
            RegisterUser_POM registeruserpom = new(driver);
            registeruserpom.RegisterUser(loginError, By.CssSelector(registeruserpom.span_errorMessage), credentials.username, credentials.usernumber);

            //go backwards
            loginpom.clickOnLogOut();

        }
        [Test(), Order(1)]
        [Category("Forgot login information | forgot login information title screen")]
        public void Test01()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen and click on forgot login info
            forgotlogin.ClickonforgotButton();

            //verify message is display
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.forgotLoginInfo));


        }

        [Test(), Order(2)]
        [Category("Forgot login information | complete all fields")]
        public void Test02()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen and click on forgot login info
            // Complete all fields
            forgotlogin.Completefields(credentials.username, credentials.usernumber);


        }

        [Test(), Order(3)]
        [Category("Forgot login information | verify screen title")]
        public void Test03()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen and click on forgot login info
            // Verify message is display
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.lookingInfo));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}

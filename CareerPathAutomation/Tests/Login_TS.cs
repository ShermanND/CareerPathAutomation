using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            Driver driverSetup = new(driver);
            driverSetup.DriverSetUp();

            // Initialize login
            login = new Login_POM(driver);
            credentials = new Credentials();
            titles = new Titles();
        }      

        [Test(), Order(1)]
        [Category("Customer Login | Home Screen login")]
        public void Test01()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen and input credentials into customer login
            login.LoginUser(credentials.username, credentials.usernumber);


            // Verify login error message is not true
            bool loginError = login.GetElementIsDisplayed(By.CssSelector(login.p_errorMessage));

            //Then I verify that welcome screen is display as screen
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.accounts));

            driver.Navigate().Back();

        }

        [Test(), Order(2)]
        [Category("Customer Login | Error not register")]
        public void Test02()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen and input credentials into customer login
            login.LoginUser(credentials.invalidUsername, credentials.invalidUserNumber);

            // Verify login error message is true
            bool loginError = login.GetElementIsDisplayed(By.CssSelector(login.p_errorMessage));

            //verify error message is display
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.loginError));
        }
        
        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Dispose();
        }
    }
}

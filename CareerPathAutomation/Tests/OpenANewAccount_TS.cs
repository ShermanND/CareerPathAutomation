using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using CareerPathAutomation.POM;

namespace CareerPathAutomation.Tests
{
    public class OpenANewAccount_TS
    {
        private IWebDriver driver;
        private OpenANewAccount_POM newaccountpom;
        private Titles titles;

        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize driver setup
            driver = new ChromeDriver();
            Driver driverSetup = new(driver);
            driverSetup.DriverSetUp();
            titles = new Titles();

            // Login user
            Login_POM loginpom = new(driver);
            Credentials credentials = new();
            loginpom.LoginUser(credentials.username, credentials.usernumber);

            // Verify login error message is true
            bool loginError = loginpom.GetElementIsDisplayed(By.CssSelector(loginpom.p_errorMessage));

            // Register user if loginError is true
            RegisterUser_POM registeruserpom = new(driver);
            registeruserpom.RegisterUser(loginError, By.CssSelector(registeruserpom.span_errorMessage), credentials.username, credentials.usernumber);

            //Navigate to open a new account
            newaccountpom = new OpenANewAccount_POM(driver);
            newaccountpom.NavigateToOpenANewAccount();
        }

        
        [Test, Order(1)]
        [Category("Open a New Account | Open a new account title")]
        public void Test01()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Open a New account screen
            // Then I verify that Open a new account screen title is visible
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.newaccount));

        }

        [Test, Order(2)]
        [Category("Open a New Account | Open a new checking account")]
        public void Test02()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Open a new account screen
            // Then I create a new checking account
            newaccountpom.CrearNuevaCuenta();
            

        }

        [Test, Order(3)]
        [Category("Open a New Account | Verify account created title")]
        public void Test03()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Open a new account screen
            // Then I create a new checking account and verify account created title
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.newaccountcreated));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}

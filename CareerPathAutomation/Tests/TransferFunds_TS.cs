using CareerPathAutomation.POM;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace CareerPathAutomation.Tests
{
    public class TransferFunds_TS
    {
        private IWebDriver driver;
        private TransferFunds_POM transferfundspom;
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

            // Navigate to Transfer funds screen
            transferfundspom = new TransferFunds_POM(driver);
            transferfundspom.NavigateTotransferFundsLink();

            //load funds screen
           transferfundspom.LoadFundsScreen();

            //verificar cuentas
            if (!transferfundspom.VerificarCuentas())
            {
                OpenANewAccount_POM nuevaCuenta = new(driver);

                nuevaCuenta.NavigateToOpenANewAccount();
                nuevaCuenta.CrearNuevaCuenta();
                transferfundspom.NavigateTotransferFundsLink();
                transferfundspom.LoadFundsScreen();
            }
        }

        [Test, Order(1)]
        [Category("Transfer funds | Transfer funds title")]
        public void Test01()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Transfer fund screen
            // Then I verify that Transfer fund title is visible
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.transferfunds));

        }

        
        [Test, Order(2)]
        [Category("Transfer funds | Transfer funds")]
        public void Test02()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Transfer fund screen
            // Then I verify that I'm able to transfer
            //vuelve a cargar
            transferfundspom.transferFunds(100, 0, 1);
        }

        [Test, Order(3)]
        [Category("Transfer funds | Verify transfer is complete")]
        public void Test03()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Transfer fund screen and transfer funds
            // Then I verify transfer funds complete title
            string title = driver.Title;
            Assert.That(title, Is.EqualTo(titles.transferfunds));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}

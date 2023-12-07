using CareerPathAutomation.POM;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using OpenQA.Selenium.Support.UI;
using System.Threading;

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
            Driver driverSetup = new Driver(driver);
            driverSetup.DriverSetUp();
            titles = new Titles();

            // Login user
            Login_POM loginpom = new Login_POM(driver);
            Credentials credentials = new Credentials();
            loginpom.LoginUser(credentials.username, credentials.usernumber);

            // Verify login error message is true
            Boolean loginError = loginpom.GetElementIsDisplayed(By.CssSelector(loginpom.p_errorMessage));

            // Register user if loginError is true
            RegisterUser_POM registeruserpom = new RegisterUser_POM(driver);
            registeruserpom.RegisterUser(loginError, By.CssSelector(registeruserpom.span_errorMessage), credentials.username, credentials.usernumber);

            // Navigate to Transfer funds screen
            transferfundspom = new TransferFunds_POM(driver);
            transferfundspom.NavigateTotransferFundsLink();

            //load funds screen
           transferfundspom.LoadFundsScreen();

            //verificar cuentas
            if (!transferfundspom.VerificarCuentas())
            {
                OpenANewAccount_POM nuevaCuenta = new OpenANewAccount_POM(driver);

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
            Assert.AreEqual(titles.transferfunds, title);

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
            Assert.AreEqual(titles.transferfunds, title);

        }
        
    }
}

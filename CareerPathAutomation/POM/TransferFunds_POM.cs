
using CareerPathAutomation.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CareerPathAutomation.POM
{
    public class TransferFunds_POM
    {
        private IWebDriver driver;

        
        public TransferFunds_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //locators
        private IWebElement transferFundsLink => driver.FindElement(By.XPath("//div[@id='leftPanel']/ul//a[@href='/parabank/transfer.htm']"));
        
        private IWebElement inputAmount => driver.FindElement(By.XPath("/html//input[@id='amount']"));

        private IWebElement fromAccount => driver.FindElement(By.XPath("/html//select[@id='fromAccountId']"));

        private IWebElement toAccount => driver.FindElement(By.XPath("/html//select[@id='toAccountId']"));

        private IWebElement transferFundsButton => driver.FindElement(By.XPath("//div[@id='rightPanel']/div[@class='ng-scope']//form//input[@value='Transfer']"));
        
        //methods

        public void NavigateTotransferFundsLink()
        {
            transferFundsLink.Click();
        }
       

        private void NavigateToCreateNewAccount()
        {
            OpenANewAccount_POM accountpom = new OpenANewAccount_POM(driver);
            accountpom.NavigateToOpenANewAccount();
        }

        public void transferFunds(double cantidad, int indexCuentaOrigen, int indexCuentaDestino)
        {
            //Ingresar monto
            IngresarMonto(cantidad);

            // Seleccionar la cuenta de origen
            SeleccionarCuentaDesde(indexCuentaOrigen);

            //Seleccionar la cuenta destino
            SeleccionarCuentaHasta(indexCuentaDestino);

            //Click en transferir funds
            NavigateToTransferFundsButton();
        }

        public void SeleccionarCuentaHasta(int index)
        {
            SelectElement select = new SelectElement(fromAccount);
            select.SelectByIndex(index);
        }

        public void SeleccionarCuentaDesde(int index)
        {
            SelectElement select = new SelectElement(toAccount);
            select.SelectByIndex(index);
        }

        public void IngresarMonto(double cantidad)
        {
            if (cantidad > 0)

            {
                inputAmount.SendKeys(cantidad.ToString());
            }
        }

        public void NavigateToTransferFundsButton()
        {
            transferFundsButton.Click();
        }

        public bool VerificarCuentas()
        {
            Console.WriteLine("Entrando en Verificar2Cuentas");

            bool resultado = false;
            IWebElement dropdown = driver.FindElement(By.Id("fromAccountId"));

            SelectElement select = new SelectElement(dropdown);
            IList<IWebElement> options = select.Options;

            if (options.Count >= 2)
            {
                resultado = true;
                Console.WriteLine("Cuentas encontradas");
            }
      

            return resultado;
        }

        public void LoadFundsScreen()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement dropdown = wait.Until(driver => driver.FindElement(By.Id("fromAccountId")));

            SelectElement select = new SelectElement(dropdown);
            IList<IWebElement> options = select.Options;

            foreach (var option in options)
            {
                if (option.GetAttribute("value") != "undefined")
                {
                    option.Click();
                    break;
                }
            }
        }

    }



        
    
}

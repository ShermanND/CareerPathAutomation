using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace CareerPathAutomation.POM
{
    public class OpenANewAccount_POM
    {
        private IWebDriver driver;

        public OpenANewAccount_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //locators
        private IWebElement openANewAccountLink => driver.FindElement(By.XPath("//*[@id=\"leftPanel\"]/ul/li[1]/a"));
        private IWebElement dropdownAccountType => driver.FindElement(By.XPath("/html//select[@id='type']"));

        private IWebElement dropdownExistingAccount => driver.FindElement(By.XPath("/html//select[@id='fromAccountId']"));

        private IWebElement openANewAccountBotton => driver.FindElement(By.XPath("//div[@id='rightPanel']/div[@class='ng-scope']//form[@class='ng-pristine ng-valid']//input[@value='Open New Account']"));

        //metodos
        public void SeleccionarTipoDeCuenta(string valorASeleccionar)
        {
            SelectElement select = new SelectElement(dropdownAccountType);
            select.SelectByText(valorASeleccionar);
        }

        public void SeleccionarCuentaExistente(int index)
        {
            SelectElement select = new SelectElement(dropdownExistingAccount);
            select.SelectByIndex(index);
        }
        public void CrearNuevaCuenta()
        {
            //Aquí va la lógica para crear una nueva cuenta
            SeleccionarTipoDeCuenta("CHECKING");
            SeleccionarCuentaExistente(0);
            Thread.Sleep(10);
            NavigateToClickOnOpenANewAccount();
        }
        public void NavigateToOpenANewAccount()
        {
            openANewAccountLink.Click();
        }

        public void NavigateToClickOnOpenANewAccount()
        {
            openANewAccountBotton.Click();
        }

     



    }
}

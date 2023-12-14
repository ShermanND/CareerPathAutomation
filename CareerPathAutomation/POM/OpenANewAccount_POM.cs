using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CareerPathAutomation.POM
{
    public class OpenANewAccount_POM(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        //locators
        private IWebElement OpenANewAccountLink => driver.FindElement(By.XPath("//*[@id=\"leftPanel\"]/ul/li[1]/a"));
        private IWebElement DropdownAccountType => driver.FindElement(By.XPath("/html//select[@id='type']"));

        private IWebElement DropdownExistingAccount => driver.FindElement(By.XPath("/html//select[@id='fromAccountId']"));

        private IWebElement OpenANewAccountBotton => driver.FindElement(By.XPath("//div[@id='rightPanel']/div[@class='ng-scope']//form[@class='ng-pristine ng-valid']//input[@value='Open New Account']"));

        //metodos
        public void SeleccionarTipoDeCuenta(string valorASeleccionar)
        {
            SelectElement select = new(DropdownAccountType);
            select.SelectByText(valorASeleccionar);
        }

        public void SeleccionarCuentaExistente(int index)
        {
            SelectElement select = new(DropdownExistingAccount);
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
            OpenANewAccountLink.Click();
        }

        public void NavigateToClickOnOpenANewAccount()
        {
            OpenANewAccountBotton.Click();
        }

     



    }
}

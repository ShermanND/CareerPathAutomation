using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPathAutomation
{
    public class HomeMenu_POM
    {
        private IWebDriver driver;
        public HomeMenu_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement aboutUs => driver.FindElement(By.CssSelector("#headerPanel > ul.leftmenu > li:nth-child(2) > a"));
        public void clickonAboutUs()
        {
            aboutUs.Click();
        }

        IWebElement Product => driver.FindElement(By.CssSelector("#headerPanel > ul.leftmenu > li:nth-child(4) > a"));
        public void clickonProduct()
        {
            Product.Click();
        }
        IWebElement Locations => driver.FindElement(By.CssSelector("#headerPanel > ul.leftmenu > li:nth-child(5) > a"));
        public void clickonLocations()
        {
            Locations.Click();
        }

        IWebElement homescreen => driver.FindElement(By.XPath("//li[@class='home']/a"));
        public void clickonHomeScreen()
        {
            homescreen.Click();
        }

        IWebElement customerCare => driver.FindElement(By.XPath("//div[@id='headerPanel']/ul[@class='button']//a[@href='contact.htm']"));
        public void clickonCustomerCare()
        {
            customerCare.Click();
        }
    }
}

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
    }
}

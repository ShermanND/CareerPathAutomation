using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HomeFooter_POM
{
    private IWebDriver driver;

    public HomeFooter_POM(IWebDriver driver)
	{
        this.driver = driver;
    }

    // SELECTORS
    public string homeFooter = "//*[@id=\"footerPanel\"]/ul[1]/li[1]/a";
    public string aboutUsFooter = "//*[@id=\"footerPanel\"]/ul[1]/li[2]/a";
    public string servicesFooter = "//*[@id=\"footerPanel\"]/ul[1]/li[3]/a";
    public string productsFooter = "//*[@id=\"footerPanel\"]/ul[1]/li[4]/a";
    public string locationsFooter = "//*[@id=\"footerPanel\"]/ul[1]/li[5]/a";
    public string forumFooter = "//*[@id=\"footerPanel\"]/ul[1]/li[6]/a";
    public string siteMapFooter = "//*[@id=\"footerPanel\"]/ul[1]/li[7]/a";
    public string contactUsFooter = "//*[@id=\"footerPanel\"]/ul[1]/li[8]/a";
    public string parasoftLink = "//*[@id=\"footerPanel\"]/ul[2]/li[2]/a";

    // HTML TITLE
    public string titleHome = "ParaBank | Welcome | Online Banking";
    public string titleAboutUs = "ParaBank | About Us";
    public string titleServices = "ParaBank | Services";
    public string titleSiteMap = "ParaBank | Site Map";
    public string titleCustomerCare = "ParaBank | Customer Care";

    // METHODS
    public void NavigateToHomeFooter()
    {
        driver.FindElement(By.XPath(homeFooter)).Click();
    }

    public void NavigateToAboutUsFooter()
    {
        driver.FindElement(By.XPath(aboutUsFooter)).Click();
    }

    public void NavigateToServicesFooter()
    {
        driver.FindElement(By.XPath(servicesFooter)).Click();
    }

    public void NavigateToProductsFooter()
    {
        driver.FindElement(By.XPath(productsFooter)).Click();
    }

    public void NavigateToLocationsFooter()
    {
        driver.FindElement(By.XPath(locationsFooter)).Click();
    }

    public void NavigateToForumFooter()
    {
        driver.FindElement(By.XPath(forumFooter)).Click();
    }

    public void NavigateToSiteMapFooter()
    {
        driver.FindElement(By.XPath(siteMapFooter)).Click();
    }

    public void NavigateToContactUsFooter()
    {
        driver.FindElement(By.XPath(contactUsFooter)).Click();
    }

    public void NavigateToParasoftLinkFooter()
    {
        driver.FindElement(By.XPath(parasoftLink)).Click();
    }

}

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

    // HTML TITLE
    public string title = "ParaBank | Welcome | Online Banking";

    // METHODS
    public void NavigateToHomeFooter()
    {
        driver.findElement(By.xpath(homeFooter)).click();
    }

    public void NavigateToAboutUsFooter()
    {
        driver.findElement(By.xpath(aboutUsFooter)).click();
    }

    public void NavigateToServicesFooter()
    {
        driver.findElement(By.xpath(servicesFooter)).click();
    }

    public void NavigateToProductsFooter()
    {
        driver.findElement(By.xpath(productsFooter)).click();
    }

    public void NavigateToLocationsFooter()
    {
        driver.findElement(By.xpath(locationsFooter)).click();
    }

    public void NavigateToForumFooter()
    {
        driver.findElement(By.xpath(forumFooter)).click();
    }

    public void NavigateToSiteMapFooter()
    {
        driver.findElement(By.xpath(siteMapFooter)).click();
    }

    public void NavigateToContactUsFooter()
    {
        driver.findElement(By.xpath(contactUsFooter)).click();
    }

}

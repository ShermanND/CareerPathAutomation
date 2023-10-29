using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;
using System.Reflection.Emit;

public class UpdatingContactInformation_POM
{
    private IWebDriver driver;

    public UpdatingContactInformation_POM(IWebDriver driver)
    {
        this.driver = driver;
    }

    // SELECTORS    
    public string btn_updateProfile = "input[class=\"button\"]";

    public string h1_title = "h1[class=\"title\"]";

    public string input_firstName = "table[class=\"form2\"] tr:nth-child(1) input";
    public string input_lastName = "table[class=\"form2\"] tr:nth-child(2) input";
    public string input_address = "table[class=\"form2\"] tr:nth-child(3) input";
    public string input_city = "table[class=\"form2\"] tr:nth-child(4) input";
    public string input_state = "table[class=\"form2\"] tr:nth-child(5) input";
    public string input_zipCode = "table[class=\"form2\"] tr:nth-child(6) input";
    public string input_phoneNumber = "table[class=\"form2\"] tr:nth-child(7) input";

    public string p_successfulUpdateMessage = "div[ng-if=\"showResult\"] p";

    public string span_firsNameRequired = "table[class=\"form2\"] tr:nth-child(1) span";
    public string span_lastNameRequired = "table[class=\"form2\"] tr:nth-child(2) span";
    public string span_addressRequired = "table[class=\"form2\"] tr:nth-child(3) span";
    public string span_cityRequired = "table[class=\"form2\"] tr:nth-child(4) span";
    public string span_stateRequired = "table[class=\"form2\"] tr:nth-child(5) span";
    public string span_zipCodeRequired = "table[class=\"form2\"] tr:nth-child(6) span";
    public string span_phoneNumberRequired = "table[class=\"form2\"] tr:nth-child(7) span";

    public string link_updateContactInfo = "a[href=\"/parabank/updateprofile.htm\"]";

    public string form_inputs = "table[class=\"form2\"] input[type=\"text\"]";
    public string form_labels = "td[align=\"right\"] b";

    // ERROR MESSAGE
    public string error_firstName = "First name is required.";
    public string error_lastName = "Last name is required.";
    public string error_address = "Address is required.";
    public string error_city = "City is required.";
    public string error_state = "State is required.";
    public string error_zipCode = "Zip Code is required.";

    // HTML TITLE
    public string title_updateProfile = "ParaBank | Update Profile";

    // LABEL TITLE
    public string updateProfile = "Update Profile";
    public string profileUpdated = "Profile Updated";

    // ELEMENT TEXT
    public List<string> tablelabels = new List<string> { "First Name:", "Last Name:", "Address:", "City:", "State:", "Zip Code:", "Phone #:" };
    public string successfulUpdateMessage = "Your updated address and phone number have been added to the system.";

    // USER CREDENTIAL
    public string user = "user1";

    public void NavigateToUpdatingContactInformation()
    {
        driver.FindElement(By.CssSelector(link_updateContactInfo)).Click();
    }

    public void VerifyElementText(By selector, string screentitle)
    {
        string screenTitle = driver.FindElement(selector).Text;
        Assert.That(screenTitle, Is.EqualTo(screentitle));
    }

    public void VerifyWebElementsLabels(By selector, List<string> elementslabels)
    {
        var webElements = driver.FindElements(selector);
        List<string> elementsLabels = new List<string>();

        foreach (IWebElement webElement in webElements)
        {
            string name = webElement.Text;
            elementsLabels.Add(name);
        }

        Assert.That(elementsLabels, Is.EqualTo(elementslabels));
    }

    public void CleanInputField(By selector)
    {
        driver.FindElement(selector).Clear();
    }

    public void VerifyErrorMessage(By selector, string errormessage)
    {
        string errorMessage = driver.FindElement(selector).Text;
        Assert.That(errorMessage, Is.EqualTo(errormessage));
    }

    public void ClickElement(By selector)
    {
        driver.FindElement(selector).Click();
    }

    public void VerifyElementValue(By selector, string value)
    {
        string elementValue = driver.FindElement(selector).GetAttribute("value");
        Assert.That(elementValue, Is.EqualTo(value));
    }

    public void VerifyElementIsDisplayed(By selector)
    {
        Boolean elementDisplayed = driver.FindElement(selector).Displayed;
        Assert.IsTrue(elementDisplayed);
    }

    public void VerifyElementsAreDisplayed(By selector)
    {
        var webElements = driver.FindElements(selector);

        foreach (var webElement in webElements)
        {
            Boolean elementDisplayed = webElement.Displayed;
            Assert.IsTrue(elementDisplayed);
        }
    }

    public void CleanInputFields(By selector)
    {
        var webElements = driver.FindElements(selector);

        foreach (var webElement in webElements)
        {
            webElement.Clear();
        }
    }

    public void FillInInputField(By selector)
    {
        var webElements = driver.FindElements(selector);

        foreach (var webElement in webElements)
        {
            webElement.SendKeys(user);
        }
    }

    public Boolean GetElementIsDisplayed(By selector)
    {
        Boolean elementDisplayed = driver.FindElement(selector).Displayed;
        return elementDisplayed;
    }

    public void VerifyElementIsNotDisplayed(By selector)
    {
        Boolean errorDisplayed;

        try
        {
            errorDisplayed = driver.FindElement(selector).Displayed;
        }

        catch (NoSuchElementException)
        {
            errorDisplayed = false;
        }

        Assert.IsFalse(errorDisplayed, "Required field error message is displayed");
    }
}
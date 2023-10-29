using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CareerPathAutomation
{
    [TestFixture]
    public class UpdatingContactInformation
    {
        IWebDriver driver;
        UpdatingContactInformation_POM updatingcontactinformationpom;

        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize driver setup
            driver = new ChromeDriver();
            Driver_POM driverpom = new Driver_POM(driver);
            driverpom.DriverSetUp();

            // Verify login error message is true
            Login_POM loginpom = new Login_POM(driver);
            Boolean loginError = loginpom.GetElementIsDisplayed(By.CssSelector(loginpom.p_errorMessage));

            // Register user if loginError is true
            RegisterUser_POM registeruserpom = new RegisterUser_POM(driver);
            registeruserpom.RegisterUser(loginError);

            // Navigate to Update Profile screen
            updatingcontactinformationpom = new UpdatingContactInformation_POM(driver);
            updatingcontactinformationpom.NavigateToUpdatingContactInformation();

            Thread.Sleep(3000);
        }

        [Test, Order(1)]
        [Category("Update Contact Info | Update Profile screen title is visible")]
        public void Test0201()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Update Profile screen
            // Then I verify that Update Profile screen title is visible
            updatingcontactinformationpom.VerifyElementIsDisplayed(By.CssSelector(updatingcontactinformationpom.h1_title));
        }

        [Test, Order(2)]
        [Category("Update Contact Info | Screen title text is Update Profile")]
        public void Test0202()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Update Profile screen
            // Then I verify that screen title text is Update Profile
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), updatingcontactinformationpom.updateProfile);
        }

        [Test, Order(3)]
        [Category("Update Contact Info | First Name:, Last Name:, Address:, City:, State:, Zip Code:, Phone #: labels are visible")]
        public void Test0203()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Update Profile screen
            // Then I verify that First Name:, Last Name:, Address:, City:, State:, Zip Code:, Phone #: labels are visible
            updatingcontactinformationpom.VerifyElementsAreDisplayed(By.CssSelector(updatingcontactinformationpom.form_labels));
        }

        [Test, Order(4)]
        [Category("Update Contact Info | First Name:, Last Name:, Address:, City:, State:, Zip Code:, Phone #: are displayed as labels")]
        public void Test0204()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Update Profile screen
            // Then I verify that First Name:, Last Name:, Address:, City:, State:, Zip Code:, Phone #: are displayed as labels
            updatingcontactinformationpom.VerifyWebElementsLabels(By.CssSelector(updatingcontactinformationpom.form_labels), updatingcontactinformationpom.tablelabels);
        }

        [Test, Order(5)]
        [Category("Update Contact Info | First Name is a required field")]
        public void Test0205()
        {
            // Given I have accessed to Parabank website
            // And I have navigated to Update Profile screen
            // When I clean the First Name field
            updatingcontactinformationpom.CleanInputField(By.CssSelector(updatingcontactinformationpom.input_firstName));

            // Then I verify that the following message is displayed: "First Name is required."
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_firsNameRequired), updatingcontactinformationpom.error_firstName);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), updatingcontactinformationpom.updateProfile);
        }

        [Test, Order(6)]
        [Category("Update Contact Info | Last Name is a required field")]
        public void Test0206()
        {
            // Given I have accessed to Parabank website
            // And I have navigated to Update Profile screen
            // When I clean the Last Name field
            updatingcontactinformationpom.CleanInputField(By.CssSelector(updatingcontactinformationpom.input_lastName));

            // Then I verify that the following message is displayed: "Last Name is required."
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_lastNameRequired), updatingcontactinformationpom.error_lastName);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), updatingcontactinformationpom.updateProfile);
        }

        [Test, Order(7)]
        [Category("Update Contact Info | Address is a required field")]
        public void Test0207()
        {
            // Given I have accessed to Parabank website
            // And I have navigated to Update Profile screen
            // When I clean the Address field
            updatingcontactinformationpom.CleanInputField(By.CssSelector(updatingcontactinformationpom.input_address));

            // Then I verify that the following message is displayed: "Address is required."
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_addressRequired), updatingcontactinformationpom.error_address);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), updatingcontactinformationpom.updateProfile);
        }

        [Test, Order(8)]
        [Category("Update Contact Info | City is a required field")]
        public void Test0208()
        {
            // Given I have accessed to Parabank website
            // And I have navigated to Update Profile screen
            // When I clean the City field
            updatingcontactinformationpom.CleanInputField(By.CssSelector(updatingcontactinformationpom.input_city));

            // Then I verify that the following message is displayed: "City is required."
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_cityRequired), updatingcontactinformationpom.error_city);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), updatingcontactinformationpom.updateProfile);
        }

        [Test, Order(9)]
        [Category("Update Contact Info | State is a required field")]
        public void Test0209()
        {
            // Given I have accessed to Parabank website
            // And I have navigated to Update Profile screen
            // When I clean the State field
            updatingcontactinformationpom.CleanInputField(By.CssSelector(updatingcontactinformationpom.input_state));

            // Then I verify that the following message is displayed: "State is required."
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_stateRequired), updatingcontactinformationpom.error_state);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), updatingcontactinformationpom.updateProfile);
        }

        [Test, Order(10)]
        [Category("Update Contact Info | Zip Code is a required field")]
        public void Test0210()
        {
            // Given I have accessed to Parabank website
            // And I have navigated to Update Profile screen
            // When I clean the Zip Code field
            updatingcontactinformationpom.CleanInputField(By.CssSelector(updatingcontactinformationpom.input_zipCode));

            // Then I verify that the following message is displayed: "Zip Code is required."
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_zipCodeRequired), updatingcontactinformationpom.error_zipCode);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), updatingcontactinformationpom.updateProfile);
        }

        [Test, Order(11)]
        [Category("Update Contact Info | Phone #: is not a required field")]
        public void Test0211()
        {
            // Given I have accessed to Parabank website
            // And I have navigated to Update Profile screen
            // When I clean the Phone #: field
            updatingcontactinformationpom.CleanInputField(By.CssSelector(updatingcontactinformationpom.input_phoneNumber));

            // Then I verify that there is no error message displayed
            updatingcontactinformationpom.VerifyElementIsNotDisplayed(By.CssSelector(updatingcontactinformationpom.span_phoneNumberRequired));

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));
            Thread.Sleep(2000);

            // Then I verify that the changes are applied
            // And I verify that I navigate to Profile Updated screen
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), updatingcontactinformationpom.profileUpdated);

            // And I verify that the following message is displayed: "Your updated address and phone number have been added to the system."
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.p_successfulUpdateMessage), updatingcontactinformationpom.successfulUpdateMessage);
        }

        [Test, Order(12)]
        [Category("Update Contact Info | Update Profile button is displayed")]
        public void Test0212()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Update Profile screen
            // Then I verify that Update Profile button is displayed
            updatingcontactinformationpom.VerifyElementIsDisplayed(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));
        }

        [Test, Order(13)]
        [Category("Update Contact Info | Update Profile button value is Update Profile")]
        public void Test0213()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Update Profile screen
            // Then I verify that Update Profile button value is Update Profile
            updatingcontactinformationpom.VerifyElementValue(By.CssSelector(updatingcontactinformationpom.btn_updateProfile), updatingcontactinformationpom.updateProfile);
        }

        [Test, Order(14)]
        [Category("Update Contact Info | User is able to update contact information")]
        public void Test0214()
        {
            // Given I have accessed to Parabank website
            // And I have navigated to Update Profile screen
            // And I have made some changes on the fields
            updatingcontactinformationpom.CleanInputFields(By.CssSelector(updatingcontactinformationpom.form_inputs));
            updatingcontactinformationpom.FillInInputField(By.CssSelector(updatingcontactinformationpom.form_inputs));

            // When I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));
            Thread.Sleep(1000);

            // Then I verify that the changes are applied
            // And I verify that I navigate to Profile Updated screen
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), updatingcontactinformationpom.profileUpdated);

            // And I verify that the following message is displayed: "Your updated address and phone number have been added to the system."
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.p_successfulUpdateMessage), updatingcontactinformationpom.successfulUpdateMessage);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
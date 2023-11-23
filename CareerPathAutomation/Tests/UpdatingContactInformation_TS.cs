using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using CareerPathAutomation.Data;
using CareerPathAutomation.POM;
using CareerPathAutomation.SetUp;

namespace CareerPathAutomation.Tests
{
    [TestFixture]
    public class UpdatingContactInformation
    {
        private IWebDriver driver;
        private UpdatingContactInformation_POM updatingcontactinformationpom;

        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize driver setup
            driver = new ChromeDriver();
            Driver driverSetup = new Driver(driver);
            driverSetup.DriverSetUp();

            // Login user
            Login_POM loginpom = new Login_POM(driver);
            Credentials credentials = new Credentials();
            loginpom.LoginUser(credentials.username, credentials.usernumber);

            // Verify login error message is true
            Boolean loginError = loginpom.GetElementIsDisplayed(By.CssSelector(loginpom.p_errorMessage));

            // Register user if loginError is true
            RegisterUser_POM registeruserpom = new RegisterUser_POM(driver);
            registeruserpom.RegisterUser(loginError, By.CssSelector(registeruserpom.span_errorMessage), credentials.username, credentials.usernumber);

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
            Titles titles = new Titles();
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), titles.updateProfile);
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
            Labels labels = new Labels();
            updatingcontactinformationpom.VerifyElementsLabels(By.CssSelector(updatingcontactinformationpom.form_labels), labels.updateContactInfo);
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
            Messages messages = new Messages();
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_firsNameRequired), messages.firstNameRequired);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            Titles titles = new Titles();
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), titles.updateProfile);
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
            Messages messages = new Messages();
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_lastNameRequired), messages.lastNameRequired);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            Titles titles = new Titles();
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), titles.updateProfile);
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
            Messages messages = new Messages();
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_addressRequired), messages.addressRequired);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            Titles titles = new Titles();
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), titles.updateProfile);
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
            Messages messages = new Messages();
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_cityRequired), messages.cityRequired);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            Titles titles = new Titles();
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), titles.updateProfile);
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
            Messages messages = new Messages();
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_stateRequired), messages.stateRequired);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            Titles titles = new Titles();
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), titles.updateProfile);
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
            Messages messages = new Messages();
            updatingcontactinformationpom.VerifyErrorMessage(By.CssSelector(updatingcontactinformationpom.span_zipCodeRequired), messages.zipCodeRequired);

            // And I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));

            // And I verify that the changes are not applied
            // And I verify that I remain on the same screen
            Titles titles = new Titles();
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), titles.updateProfile);
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
        }

        [Test, Order(12)]
        [Category("Update Contact Info | Update Profile button is visible")]
        public void Test0212()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Update Profile screen
            // Then I verify that Update Profile button is visible
            updatingcontactinformationpom.VerifyElementIsDisplayed(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));
        }

        [Test, Order(13)]
        [Category("Update Contact Info | Update Profile button value is Update Profile")]
        public void Test0213()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Update Profile screen
            // Then I verify that Update Profile button value is Update Profile
            Labels labels = new Labels();
            updatingcontactinformationpom.VerifyElementValue(By.CssSelector(updatingcontactinformationpom.btn_updateProfile), labels.updateProfile);
        }

        [Test, Order(14)]
        [Category("Update Contact Info | User is able to update contact information")]
        public void Test0214()
        {
            // Given I have accessed to Parabank website
            // And I have navigated to Update Profile screen
            // And I have made some changes on the fields
            Credentials credentials = new Credentials();
            updatingcontactinformationpom.CleanInputFields(By.CssSelector(updatingcontactinformationpom.form_inputs));
            updatingcontactinformationpom.FillInInputField(By.CssSelector(updatingcontactinformationpom.form_inputs), credentials.username, credentials.usernumber);

            // When I click on Update Profile button
            updatingcontactinformationpom.ClickElement(By.CssSelector(updatingcontactinformationpom.btn_updateProfile));
            Thread.Sleep(1000);

            // Then I verify that the changes are applied
            // And I verify that I navigate to Profile Updated screen
            Titles titles = new Titles();
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.h1_title), titles.profileUpdated);

            // And I verify that the following message is displayed: "Your updated address and phone number have been added to the system."
            Messages messages = new Messages();
            updatingcontactinformationpom.VerifyElementText(By.CssSelector(updatingcontactinformationpom.p_successfulUpdateMessage), messages.successfulUpdate);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}

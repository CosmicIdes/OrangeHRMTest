using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OrangeHRMTest
{
    [TestClass]
    public class LoginPageTests
    {
        public IWebDriver _webDriver;
        public LoginPage _loginPage;
        public SeleniumHelpers _seleniumHelpers;

        [TestInitialize]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _loginPage = new LoginPage(_webDriver);
            _seleniumHelpers = new SeleniumHelpers(_webDriver);
        }

        [TestMethod]
        public void LoginAdminSuccessful()
        {
            WebDriverWait webdriverwait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));

            _webDriver.Navigate().GoToUrl(_loginPage.loginPageUrl);
            Assert.AreEqual("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login", _webDriver.Url);
            webdriverwait.Until(d => _loginPage.usernameTextBox.Displayed);
            _loginPage.usernameTextBox.SendKeys("Admin");
            _loginPage.passwordTextBox.SendKeys("admin123");
            _seleniumHelpers.clickButton(_loginPage.loginButton);
            Assert.AreEqual("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index", _webDriver.Url);
        }

        [TestMethod]
        public void LoginAdminUnsuccessful()
        {
            WebDriverWait webdriverwait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            _webDriver.Navigate().GoToUrl(_loginPage.loginPageUrl);
            Assert.AreEqual("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login", _webDriver.Url);
            webdriverwait.Until(d => _loginPage.usernameTextBox.Displayed);
            _loginPage.usernameTextBox.SendKeys("Admin");
            _loginPage.passwordTextBox.SendKeys("wrongpassword");
            _seleniumHelpers.clickButton(_loginPage.loginButton);
            Assert.AreEqual("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login", _webDriver.Url);
        }


        [TestCleanup]
        public void Cleanup()
        {
            _webDriver.Quit();
            _webDriver.Dispose();
        }

    }
}

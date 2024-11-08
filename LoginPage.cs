using OpenQA.Selenium;

namespace OrangeHRMTest
{
    public class LoginPage
    {
        public IWebDriver _webDriver;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string loginPageUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        public IWebElement usernameTextBox => _webDriver.FindElement(By.XPath("//input[@name='username']"));
        public IWebElement passwordTextBox => _webDriver.FindElement(By.XPath("//input[@name='password']"));
        public IWebElement loginButton => _webDriver.FindElement(By.XPath("//button[@type='submit']"));

    }
}

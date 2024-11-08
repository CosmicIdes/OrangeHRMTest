using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V127.Page;

namespace OrangeHRMTest
{
    public class SeleniumHelpers
    {
        public IWebDriver _webDriver;
        public LoginPage _loginPage;
        public SeleniumHelpers(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        

        public void LoginAsAdmin(string Login)
        {
            _webDriver.Navigate().GoToUrl(_loginPage.loginPageUrl);
            _loginPage.usernameTextBox.SendKeys("Admin");
            _loginPage.passwordTextBox.SendKeys("admin123");
            _loginPage.loginButton.Click();
        }

        public void SelectTextFromDropdown(IWebElement element, string dropdownText)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(dropdownText);
        }

        public void SelectValueFromDropdown(IWebElement element, string dropdownValue)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(dropdownValue);
        }

        public void SelectIndexFromDropdown(IWebElement element, int dropdownIndex)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(dropdownIndex);
        }

        public void clickButton(IWebElement element)
        {
            Actions a = new Actions(_webDriver);
            a.ScrollToElement(element).Click(element).Perform();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace uk.co.edgewordstraining.nfocus.edward.cabrini.POM_s
{
    public class LoginPOM
    {
        //Instatiate driver
        private IWebDriver driver;

        public LoginPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        //Paramaterise web elements
        public IWebElement UsernameField => driver.FindElement(By.CssSelector("input#username"));
        public IWebElement PasswordField => driver.FindElement(By.CssSelector("input#password"));
        public IWebElement Submit => driver.FindElement(By.CssSelector("button[name='login']"));
        public LoginPOM Login (String Username, String Password)
        {
            //Send commands to driver
            //Insert fresh username
            UsernameField.Click();
            UsernameField.Clear();
            UsernameField.SendKeys(Username);
            //Insert fresh password
            PasswordField.Click();
            PasswordField.Clear();
            PasswordField.SendKeys(Password);
            //Click login button
            Submit.Click();
            return this;
        }
    }
}

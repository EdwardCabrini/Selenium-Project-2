using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace uk.co.edgewordstraining.nfocus.edward.cabrini.Features
{
    [Binding]
    public class LoginToEdgewordsTrainingSiteSteps : HelperLibrary.WebDriverHandler
    {
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
        driver.Url = baseUrl;
    }
        
        [When(@"I login with '(.*)' and '(.*)'")]
        public void WhenILoginWithAnd(string p0, string p1)
        {
        IWebElement usernameField = driver.FindElement(By.Id("username")).Click();
        usernameField.Clear();
        usernameField.SendKeys("edward.cabrini@nfocus.co.uk");
        IWebElement passwordField = driver.FindElement(By.Id("password")).Click();
        passwordField.Clear();
        passwordField.SendKeys("Man_of_Chaos2567");
        driver.FindElement(By.LinkText("Log in")).Click;
        WebDriverWait firstWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }
        
        [Then(@"I am on the My Account page")]
        public void ThenIAmOnTheMyAccountPage()
        {
            driver.FindElement(By.XPath("//<title>My account - Edgewords Shop</title>");
            Assert.Pass("Login Succesful");
        }
    }
}

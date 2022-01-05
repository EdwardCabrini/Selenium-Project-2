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
    public class AccessShopSteps
    {
        [Given(@"I am on the My Account page")]
        public void GivenIAmOnTheMyAccountPage()
        {
            driver.Url = baseUrl;
        }
        
        [When(@"I access the Shop page")]
        public void WhenIAccessTheShopPage()
        {
            driver.FindElement(By.LinkText("Shop")).Click();
        }
        
        [Then(@"I add a '(.*)' to cart")]
        public void ThenIAddAToCart(string p0)
        {
            public WebElement.Id cartProductLink = driver.FindElement(By.Id("27"));
            public String productName = driver.FindElement(By.Name("Beanie"));
            cartProductLink.Click;
        }
        
        [Then(@"I access the Cart Page")]
        public void ThenIAccessTheCartPage()
        {
            driver.FindElement(By.LinkText("Cart")).Click();
        }
        
        [Then(@"I have the same '(.*)' in cart table")]
        public void ThenIHaveTheSameInCartTable(string p0)
        {
        if (productName = driver.FindElement(By.Name(.*));
            {
                Assert.Pass("Cart conatains correct item");
            }
        }
    }
}

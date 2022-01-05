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
    public class ApplyCouponSteps
    {

        [When(@"I am on the Cart page")]
        public void WhenIAmOnTheCartPage()
        {
            public IWebDriver driver = https://www.edgewordstraining.co.uk/demo-site/Cart/;
        }
        
        [Then(@"I apply coupon code '(.*)'")]
        public void ThenIApplyCouponCode(string p0)
        {
            object inputField = driver.FindElement(By.Id("Coupon_code"));
            inputField.Clear();
            inputField.SendKeys("edgewords");
            driver.FindElement(By.LinkText("Apply coupon")).Click;
        }

        [Then(@"Subtotal is equal to %15 less than Item's original price")]
        public void ThenSubtotalIsEqualToLessThanOriginalPrice(int p0, string p1)
        {
            public decimal originalPrice = driver.FindElement(By.Class("product-price")).getAttribute("Price");
            public decimal couponPrice = originalPrice - (driver.FindElement(By.Class("woocomerce-Price-amount amount")).getAttribute("Price"));
            public decimal expectedCouponPrice = (originalPrice / 15) * 100;

            if (couponPrice = expectedCouponPrice)
            {
                Assert.Pass("Coupon code applied %15 discount correctly");
            }
            else
            {
                Assert.Fail("Math error");
            }
        }
    }
}

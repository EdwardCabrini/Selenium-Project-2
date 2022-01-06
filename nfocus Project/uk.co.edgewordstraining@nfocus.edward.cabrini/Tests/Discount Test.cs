using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace uk.co.edgewordstraining.nfocus.edward.cabrini.Tests
{
    [Binding]
    public class DiscountTest : HelperLibrary.WebDriverHandler
    {
        //Login Steps
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Url = baseUrl;
        }

        [When(@"I login with '(.*)' and '(.*)'")]
        public void WhenILoginWithAnd(string p0, string p1)
        {
            IWebElement usernameField = driver.FindElement(By.Id("username"));
            usernameField.Click();
            usernameField.Clear();
            usernameField.SendKeys("edward.cabrini@nfocus.co.uk");
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.Click();
            passwordField.Clear();
            passwordField.SendKeys("Man_of_Chaos2567");
            driver.FindElement(By.CssSelector("button[name='login']")).Click();
            WebDriverWait firstWait = new(driver, TimeSpan.FromSeconds(5));
        }

        [Then(@"I am on the My Account page")]
        public void ThenIAmOnTheMyAccountPage()
        {
            IWebElement LogoutIsPresent = driver.FindElement(By.CssSelector(".woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--customer-logout > a"));
           
            if (LogoutIsPresent != null)
            {
                //Assert.Pass("Login Succesful");
                Console.WriteLine("Login Sucesful");
            }
            else
            {
                Assert.Fail("Login Fail");
            }
        }

        //Add item to cart and verify item Step
        string productName;

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
            IWebElement cartProductLink = driver.FindElement(By.CssSelector("[class='post-27 product type-product status-publish has-post-thumbnail product_cat-accessories first instock sale shipping-taxable purchasable product-type-simple'] .attachment-woocommerce_thumbnail"));
            productName = driver.FindElement(By.CssSelector("[class='post-27 product type-product status-publish has-post-thumbnail product_cat-accessories first instock sale shipping-taxable purchasable product-type-simple'] .woocommerce-loop-product__title")).Text;
            cartProductLink.Click();
        }

        [Then(@"I access the Cart Page")]
        public void ThenIAccessTheCartPage()
        {
            driver.FindElement(By.LinkText("Cart")).Click();
        }

        [Then(@"I have the same '(.*)' in cart table")]
        public void ThenIHaveTheSameInCartTable(string p0)
        {
            if (productName == "Beanie")
            {
                //Assert.Pass("Cart conatains correct item");
                Console.WriteLine("Cart conatains correct item");
            }
            else
            {
                Assert.Fail("Cart item Doesn't match shop item");
            }
        }
        [When(@"I am on the Cart page")]
        public void WhenIAmOnTheCartPage()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/Cart/";
        }

        //Apply coupon steps
        [Then(@"I apply coupon code '(.*)'")]
        public void ThenIApplyCouponCode(string p0)
        {
            IWebElement inputField = driver.FindElement(By.CssSelector("input#coupon_code"));
            inputField.Clear();
            inputField.SendKeys("edgewords");
            driver.FindElement(By.CssSelector("button[name='apply_coupon']")).Click();
        }

        [Then(@"Subtotal is equal to %(.*) less than item's original price")]
        public void ThenSubtotalIsEqualToLessThanOriginalPrice(int p0)
        {
            string originalPrice = driver.FindElement(By.CssSelector(".product-subtotal > .amount.woocommerce-Price-amount")).Text;
            originalPrice = originalPrice.Replace("£", "");
            decimal originalPriceDec = Decimal.Parse(originalPrice);
            string couponPrice = (driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text);
            couponPrice = couponPrice.Replace("£", "");
            decimal couponPriceDec = Decimal.Parse(couponPrice);
            decimal expectedCouponPrice = (originalPriceDec / 15) * 100;

            if (couponPriceDec == expectedCouponPrice)
            {
                Assert.Pass("Coupon code applied %15 discount correctly");
            }
            else
            {
                Assert.Fail("Discount math error");
            }
        }
    }
}

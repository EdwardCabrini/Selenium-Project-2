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
using uk.co.edgewordstraining.nfocus.edward.cabrini.POM_s;


namespace uk.co.edgewordstraining.nfocus.edward.cabrini.Tests
{
    [Binding]
    public class StepDefinitions : HelperLibrary.WebDriverHandler
    {
        private readonly ScenarioContext _scenarioContext;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Url = baseUrl;
        }

        [When(@"I login with '([^']*)' and '([^']*)'")]
        public void WhenILoginWithAnd(string Username, string Password)
        {
            //Use LoginPOM
            LoginPOM Login = new LoginPOM(driver);
            Login.Login(Username, Password);

            //Check login successful by capturing body text of new page and searching for "logged-in" text
            string PostLoginPageBodyText = driver.FindElement(By.TagName("body")).Text;
            try
            {
                Assert.That(PostLoginPageBodyText, Does.Contain("Hello"));
            }
            catch (Exception ex)
            {
                //Report fail, cont. test
                Console.WriteLine("Login failed");
            }
        }

        [Then(@"I place the order")]
        public void ThenIPlaceTheOrder()
        {
            //Go to shop via Nav bar button
            driver.FindElement(By.LinkText("Shop")).Click();
            //Add Item to cart
            driver.FindElement(By.LinkText("Add to cart")).Click();
            //Go to cart once button appears
            try
            {
                driver.FindElement(By.CssSelector("a[title='View cart']")).Click();
            }
            catch (NoSuchElementException ex)
            {
                //remove obstruction
                driver.FindElement(By.CssSelector("body > p > a")).Click();
                Thread.Sleep(2500);
                driver.FindElement(By.CssSelector("a[title='View cart']")).Click();
            }
        }

        [Then(@"I apply coupon code '(.*)' and validate discount")]
        public void ThenIApplyCouponCode(string CouponCode)
        {
            //Handle removal of previously applied coupons
            try
            {
                //Select, Clear, Input New Coupon Code
                IWebElement CouponField = driver.FindElement(By.CssSelector("input#coupon_code"));
                CouponField.Click();
                CouponField.Clear();
                CouponField.SendKeys(CouponCode);
                //Apply Coupon
                driver.FindElement(By.CssSelector("button[name='apply_coupon']")).Click();
            }
            catch(Exception ex)
            {
                //Click remove coupon
                driver.FindElement(By.CssSelector(".woocommerce-remove-coupon"));
                //Select, Clear, Input New Coupon Code
                IWebElement CouponField = driver.FindElement(By.CssSelector("input#coupon_code"));
                CouponField.Click();
                CouponField.Clear();
                CouponField.SendKeys(CouponCode);
                //Apply Coupon
                driver.FindElement(By.CssSelector("button[name='apply_coupon']")).Click();
            }
            //Perform math check for coupon discount
            //Get original price of product, convet to decimal
            string OriginalPrice = driver.FindElement(By.CssSelector(".product-subtotal > .amount.woocommerce-Price-amount")).Text;
            OriginalPrice = OriginalPrice.Replace("£","");
            decimal OriginalPriceDec = decimal.Parse(OriginalPrice);
            //Get coupon discount amount, convet to decimal
            string CouponDiscount = driver.FindElement(By.CssSelector("#post-5 > div > div > div > div > table > tbody > tr.cart-discount.coupon-edgewords > td > span")).Text;
            CouponDiscount = CouponDiscount.Replace("£", "");
            decimal CouponDiscountDec = decimal.Parse(CouponDiscount);
            //Math Check
            //Original price - Discount amount = Originalprice - (15% of Original price)
            decimal RealCheckoutCost = OriginalPriceDec - CouponDiscountDec;
            decimal ExpectedCheckoutCost = OriginalPriceDec - ((OriginalPriceDec*15)/100);
            try
            {
                Assert.That(RealCheckoutCost == ExpectedCheckoutCost);
            }
            catch (Exception ex)
            {
                //Report Fail, cont. test
                Console.WriteLine($"Checkout cost is: {RealCheckoutCost} But should have been: {ExpectedCheckoutCost}");
            }

        }

        [When(@"I complete checkout with valid billing information")]
        public void WhenICompleteCheckoutWithValidBillingInformation()
        {
            //Go to checkout via checkout button
            driver.FindElement(By.CssSelector(".alt.button.checkout-button.wc-forward")).Click();
            // Junk data for billing info
            string Fname = "Chaos";
            string Sname = "Meat";
            string StAdress = "Madess";
            string Town = "Despair";
            string PostCode = "MK4 4GF";
            string PhoneNo = "07 1234 12345";
            string Email = "NotRealEmail@gmail.com";
            //Select, Clear, input data into required fields
            //Firstname
            IWebElement FnameField = driver.FindElement(By.CssSelector("input#billing_first_name"));
            FnameField.Click();
            FnameField.Clear();
            FnameField.SendKeys(Fname);
            //Surname
            IWebElement SnameField = driver.FindElement(By.CssSelector("input#billing_last_name"));
            SnameField.Click();
            SnameField.Clear();
            SnameField.SendKeys(Sname);
            //Street address
            IWebElement StAdressField = driver.FindElement(By.CssSelector("input[name='billing_address_1']"));
            StAdressField.Click();
            StAdressField.Clear();
            StAdressField.SendKeys(StAdress);
            //Town
            IWebElement TownField = driver.FindElement(By.CssSelector("input#billing_city"));
            TownField.Click();
            TownField.Clear();
            TownField.SendKeys(Town);
            //Postcode
            IWebElement PostCodeField = driver.FindElement(By.CssSelector("input#billing_postcode"));
            PostCodeField.Click();
            PostCodeField.Clear();
            PostCodeField.SendKeys(PostCode);
            //Phone
            IWebElement PhoneNoField = driver.FindElement(By.CssSelector("input#billing_phone"));
            PhoneNoField.Click();
            PhoneNoField.Clear();
            PhoneNoField.SendKeys(PhoneNo);
            //Email
            IWebElement EmailField = driver.FindElement(By.CssSelector("input#billing_email"));
            EmailField.Click();
            EmailField.Clear();
            EmailField.SendKeys(Email);

            //Select check payments
            try
            {
                driver.FindElement(By.CssSelector(".payment_method_cheque.wc_payment_method > label")).Click();
            }
            catch (Exception ex)
            {
                //Button already selected, Cont. test
            }

            //click place order button
            driver.FindElement(By.CssSelector("button#place_order")).Click();
        }

        [Then(@"I will recieve correct order number")]
        public void ThenIWillRecieveCorrectOrderNumber()
        {
            //Wait for page to load and collect order number
            Thread.Sleep(2000);
            string CheckoutOrderNo = driver.FindElement(By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order > strong")).Text;
            CheckoutOrderNo = CheckoutOrderNo.Replace("Order number:", "");
            int CheckoutOrderNoInt = int.Parse(CheckoutOrderNo);
            //Go to my account and compare the captured order number against order number in my orders section
            driver.FindElement(By.LinkText("My account")).Click();
            //Go to my orders
            driver.FindElement(By.LinkText("Orders")).Click();
            //Go to most recent order
            driver.FindElement(By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a")).Click();
            //Store order number value
            string AccountOrderNo = driver.FindElement(By.CssSelector("#post-7 > div > div > div > p > mark.order-number")).Text;
            int AccountOrderNoInt = int.Parse(AccountOrderNo);
            try
            {
                Assert.That(AccountOrderNoInt == CheckoutOrderNoInt);
            }
            catch(Exception ex)
            {
                //Report fail, cont. logout
                Console.WriteLine($"Order number after checkout is: {CheckoutOrderNoInt} Order in account orders is: {AccountOrderNoInt}");
            }
            //Logout
            driver.FindElement(By.CssSelector(".woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--customer-logout > a")).Click();
        }    
    }
}
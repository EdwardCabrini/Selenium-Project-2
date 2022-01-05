using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static uk.co.edgewordstraining.nfocus.edward.cabrini.Helper_Library.WebDriverHandler;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace uk.co.edgewordstraining.nfocus.edward.cabrini.Helper_Library
{
    public class WebDriverHandler
    {
    public IWebDriver driver;
    public string baseUrl = https://www.edgewordstraining.co.uk/demo-site/my-account/;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
    }

    [TearDown]
    public void teardown()
    {
        driver.close();
        if (TestContext.CurrentContext.Result == ResultState.Error)
        {
            driver.Quit();
        }
    }
    }

}

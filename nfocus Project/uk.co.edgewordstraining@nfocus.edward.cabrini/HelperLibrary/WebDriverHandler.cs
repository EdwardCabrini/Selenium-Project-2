using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static uk.co.edgewordstraining.nfocus.edward.cabrini.HelperLibrary.WebDriverHandler;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace uk.co.edgewordstraining.nfocus.edward.cabrini.HelperLibrary
{
    public class WebDriverHandler
    {
    public IWebDriver driver;
    public string baseUrl = "https://www.edgewordstraining.co.uk/demo-site/my-account/";

    [Before]
    public void SetUp()
    {
        driver = new ChromeDriver();
    }

    [After]
    public void Teardown()
    {
        driver.Close();
        if (TestContext.CurrentContext.Result.Outcome == ResultState.Error)
        {
            driver.Quit();
        }
    }
    }
}

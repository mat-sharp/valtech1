using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ValTechAppTests
{
    [Binding]
    public sealed class Driver
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly IObjectContainer _objectContainer;

        public Driver(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario("StartBrowser", Order = 0)]
        public void BeforeScenario()
        {
            var optn = new ChromeOptions();
            //optn.AddArgument("--headless");
            //var service = ChromeDriverService.CreateDefaultService(@"C:\");
            //service.LogPath = "chromedriver.log";
            //service.EnableVerboseLogging = true;

            var driver = new ChromeDriver(optn);
            driver.Navigate().GoToUrl("http://valtech.co.uk/");
            driver.Manage().Window.Maximize();

            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario("TearDown")]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            driver.Quit();
        }
    }
}

using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BoDi;
using Common.Selenium;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace ValTechTest
{

    [Binding]
    public class WebDriver
    {

        private readonly IObjectContainer _objectContainer;
       

        public WebDriver(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        
        [BeforeScenario("ChromeDriver")]
        public void InitializeChromeDriver()
        {

            var optn = new ChromeOptions();
            //optn.AddArgument("--headless");
            //var service = ChromeDriverService.CreateDefaultService(@"C:\");
            //service.LogPath = "chromedriver.log";
            //service.EnableVerboseLogging = true;
            var driver = new ChromeDriver(optn);
            
            driver.Navigate().GoToUrl("http://evolve.preprod.service-plan.co.uk/");
            driver.Manage().Window.Maximize();
            
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
           

        }

        [BeforeScenario("Protractor")]
        public void InitializePolestarChromeDriver()
        {

            var optn = new ChromeOptions();
            //optn.AddArgument("--headless");
            //var service = ChromeDriverService.CreateDefaultService(@"C:\");
            //service.LogPath = "chromedriver.log";
            //service.EnableVerboseLogging = true;

            

            var driver = new ChromeDriver(optn);
            //var driver = new NgWebDriver(chromeDriver);//Protractor stuff
            
            //driver.Navigate().GoToUrl("http://www.angularjs.org");//Protractor stuff

            
            driver.Navigate().GoToUrl("http://polestar.aq2.test-plan.co.uk/Login?ReturnUrl=%2f");
            //driver.WaitForAngular();//Protractor stuff
            driver.Manage().Window.Maximize();
            

            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);


        }
        [BeforeScenario("Polestar",Order = 0)]
        public void InitializeBrowser()
        {
                                  
            var environment = new TestEnvironments().GetTestEnvironment(ConfigurationManager.AppSettings["environment"]);
            
            var optn = new ChromeOptions();
            //optn.AddArgument("--headless");
            //var service = ChromeDriverService.CreateDefaultService(@"C:\");
            //service.LogPath = "chromedriver.log";
            //service.EnableVerboseLogging = true;



            var driver = new ChromeDriver(optn);
            
            driver.Navigate().GoToUrl(environment.PolestarUrl);
            driver.Manage().Window.Maximize();

            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);


        }

        [BeforeScenario("API", Order = 0)]
        public void InitializeAPI()
        {

            var environment = new TestEnvironments().GetTestEnvironment(ConfigurationManager.AppSettings["environment"]);

            var optn = new ChromeOptions();
            //optn.AddArgument("--headless");
            //var service = ChromeDriverService.CreateDefaultService(@"C:\");
            //service.LogPath = "chromedriver.log";
            //service.EnableVerboseLogging = true;



            var driver = new ChromeDriver(optn);

            driver.Navigate().GoToUrl(environment.PolestarUrl);
            driver.Manage().Window.Maximize();

            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);


        }


        [BeforeScenario("RemoteDriver")]
        public void RemoteDriver()
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("platform", "WINDOWS");
            capability.SetCapability("browserName", "chrome");

            var driver = new RemoteWebDriver(new Uri("http://192.168.50.82:4444/wd/hub"), capability);
            

           
            driver.Navigate().GoToUrl("http://evolve.aq2.test-plan.co.uk/Default.aspx");
            driver.Manage().Window.Maximize();

            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);

        }


        [AfterScenario("Teardown")]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            driver.Quit();

        }
    }
}


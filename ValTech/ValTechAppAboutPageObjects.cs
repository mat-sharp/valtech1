using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValTech
{
    public class ValTechAppAboutPageObjects
    {

        public ValTechAppAboutPageObjects(IWebDriver driver)
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(30)));
        }

        
        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'About')]")]
        public IWebElement AboutHeader { get; set; }
    }
}

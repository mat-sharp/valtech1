using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValTech
{
    public class ValTechAppHomePageObjects
    {
        public ValTechAppHomePageObjects(IWebDriver driver)
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(30)));
        }

        //Accept Cookies
        [FindsBy(How = How.Id, Using = "CybotCookiebotDialogBodyButtonAccept")]
        public IWebElement BtnAcceptCookies { get; set; }

        //Hamburger        
        [FindsBy(How = How.XPath, Using = "//span[@class='hamburger__front']//i[@class='icons glyph']")]
        public IWebElement Hamburger { get; set; }

        //Top Menu
        [FindsBy(How = How.XPath, Using = "//ul[@class='header__navigation__menu navigation__menu']/child::li")]
        public IList<IWebElement> TopMenu { get; set; }

        //Recent Blogs Heading        
        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'recent blogs')]")]
        public IWebElement RecentBlogs { get; set; }


        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'About')]")]
        public IWebElement AboutHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Services')]")]
        public IWebElement ServicesHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Work')]")]
        public IWebElement WorkHeader { get; set; }

    }
}

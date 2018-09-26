using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValTech
{
    public class ValTechAppHomePage
    {
       
        public bool SelectFromTopMenu(IWebDriver driver, string menuOption)
        {

           ValTechAppHomePageObjects homePageObjects = new ValTechAppHomePageObjects(driver);

            //Search the topMenuOptions list for one occurance of the text in menuOption and click on it.  
            //Return false if text is not found or if more than one occurance of text is found.
            var topMenuOptions = homePageObjects.TopMenu;

            //Close Accept Cookies if displayed
            if (homePageObjects.BtnAcceptCookies.Displayed)
            {
                homePageObjects.BtnAcceptCookies.Click();
            }

            //Click on Hamburger Icon if displayed
            if (homePageObjects.Hamburger.Displayed)
            {
                homePageObjects.Hamburger.Click();
            }

            //Select the menu option from the top menu
            if (topMenuOptions.Count(x => x.Text.Equals(menuOption.ToUpper())) == 1)  
            {
                topMenuOptions.Where(x => x.Text.Equals(menuOption.ToUpper())).First().Click();
                return true;
            }
            else
            {
                return false;
            }
            
            
        }

        public bool RecentBlogsDisplayed(IWebDriver driver)
        {

            ValTechAppHomePageObjects homePageObjects = new ValTechAppHomePageObjects(driver);

            if (homePageObjects.RecentBlogs.Displayed == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool SectionVisible(IWebDriver driver, string section)
        {
            ValTechAppHomePageObjects homePageObjects = new ValTechAppHomePageObjects(driver);

            switch (section)
            {
                case ("About"):
                    if (homePageObjects.AboutHeader.Displayed)
                    {
                        return true;
                    }
                    break;
                case ("Services"):
                    if (homePageObjects.ServicesHeader.Displayed)
                    {
                        return true;
                    }
                    break;
                case ("Work"):
                    if (homePageObjects.WorkHeader.Displayed)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;

        }
    }
}

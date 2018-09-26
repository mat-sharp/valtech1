using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using ValTech;

namespace ValTechAppTests.Steps
{
    [Binding]
    public class ValTechTestSteps
    {
        private readonly IObjectContainer _objectContainer;
        public ValTechTestSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        [Given(@"That I am at the ValTech home page")]
        public void GivenThatIAmAtTheValTechHomePage()
        {

            var driver = _objectContainer.Resolve<IWebDriver>();
            Assert.That(driver.Title.Equals("Where Experiences are Engineered - Valtech"),"Not at expected page.");
           
        }

        [Then(@"The recent blogs section is displayed")]
        public void ThenTheRecentBlogsSectionIsDisplayed()
        {

           
            var driver = _objectContainer.Resolve<IWebDriver>();
            ValTechAppHomePageObjects homePageObjects = new ValTechAppHomePageObjects(driver);

            Assert.IsTrue(homePageObjects.RecentBlogs.Displayed,"Recent Blogs section not found.");

        }
        [When(@"I navugate to the menu option '(.*)'")]
        public void WhenINavugateToTheMenuOption(string menuOption)
        {

            var driver = _objectContainer.Resolve<IWebDriver>();
            ValTechAppHomePage homePage = new ValTechAppHomePage();
             

             //Select Item from TopMenu of HomePage
             Assert.True(homePage.SelectFromTopMenu(driver, menuOption), $"Could not select menu option {menuOption}");
         
        }

        [Then(@"I can see the '(.*)' header")]
        public void ThenICanSeeTheHeader(string section)
        {

            var driver = _objectContainer.Resolve<IWebDriver>();
            ValTechAppHomePage homePage = new ValTechAppHomePage();

            Assert.True(homePage.SectionVisible(driver,section),$"Could not identify header {section}");

        }



    }
}

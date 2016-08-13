using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpringerNature.UIObject;

namespace SpringerNature.Framework.Helper
{
    public class HomeHelper
    {
        private IWebDriver driver = WebDriverManager.GetDriver();
        private Home home = new Home();

        public HomeHelper()
        {
            PageFactory.InitElements(driver, home);
        }

        public void NavigateTo(String username = "CA03BW", String password = "CA03BW", string[] roles = null)
        {
            WebDriverManager.GetDriver().Navigate().GoToUrl("http://link.springer.com/");
        }

        public void SearchFor(string keyword)
        {
            home.SearchBox.Clear();
            home.SearchBox.SendKeys(keyword);
            home.SearchButton.Click();
        }
        
    }
}

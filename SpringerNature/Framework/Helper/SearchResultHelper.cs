using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpringerNature.UIObject;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpringerNature.Framework.Helper
{
    public class SearchResultHelper
    {
        private IWebDriver driver = WebDriverManager.GetDriver();
        private SearchResult searchResult = new SearchResult();

        public SearchResultHelper()
        {
            PageFactory.InitElements(driver, searchResult);
        }

        public void verifyTopSearchResult(string expectedResult)
        {
            string actualResult = searchResult.FirstSearchResult.Text;
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringerNature.UIObject
{
    class SearchResult
    {
        [FindsBy(How = How.XPath, Using = "//ol[@id='results-list']/li[1]//h2/a")]
        [CacheLookup]
        public IWebElement FirstSearchResult;
    }
}

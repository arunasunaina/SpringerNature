using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringerNature.UIObject
{
    public class Home
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='query']")]
        [CacheLookup]
        public IWebElement SearchBox;

        [FindsBy(How = How.XPath, Using = "//input[@id='search']")]
        [CacheLookup]
        public IWebElement SearchButton;
    }
}

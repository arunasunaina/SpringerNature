using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringerNature.Framework.Helper;
using SpringerNature.Framework;

namespace SpringerNature.TestMethods
{
    [TestClass]
    [DeploymentItem("phantomjs.exe")]
    [DeploymentItem("chromedriver.exe")]
    [DeploymentItem("IEDriverServer.exe")]
    public class SearchTest
    {
        [TestMethod]
        public void VerifyTopSearchResult()
        {
            HomeHelper homePage = new HomeHelper();
            homePage.NavigateTo();
            homePage.SearchFor("handbook");
            SearchResultHelper searchResultPage = new SearchResultHelper();
            searchResultPage.verifyTopSearchResult("handbook");
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            WebDriverManager.CloseDriver();
        }
    }
}

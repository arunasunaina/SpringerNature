using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringerNature.Framework.Helper;
using SpringerNature.Framework;
using SpringerNature.TestData;

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
            string[,] testData = SearchKeyData.searchKeyAndResult;
            for (int i = 0; i <= testData.GetUpperBound(0); i++)
            {
                HomeHelper homePage = new HomeHelper();
                homePage.NavigateTo();
                homePage.SearchFor(testData[i,0]);
                SearchResultHelper searchResultPage = new SearchResultHelper();
                searchResultPage.verifyTopSearchResult(testData[i, 1]);
            }
            
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            WebDriverManager.InitializeWebDriver();
            WebDriverManager.GetDriver().Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            WebDriverManager.GetDriver().Manage().Window.Maximize();

        }
        [TestCleanup()]
        public void MyTestCleanup()
        {
            WebDriverManager.CloseDriver();
        }
    }
}

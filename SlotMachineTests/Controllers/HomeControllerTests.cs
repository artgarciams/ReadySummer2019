using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using System.Web.Mvc;

namespace SlotMachine.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        //private TestContext testContextInstance;
        
        //private string appURL;
        //private object browserName;
              
        //[TestMethod]
        //[TestCategory("Chrome")]
        //public void TheBingSearchTest()
        //{
          

        //    driver.Navigate().GoToUrl(appURL + "/");
        //    driver.FindElement(By.Id("playbutton"));
        //    //driver.FindElement(By.Id("sb_form_go")).Click();
        //    //driver.FindElement(By.XPath("//ol[@id='b_results']/li/h2/a/strong[3]")).Click();
  
        //    Assert.IsTrue(driver.Title.Contains("Spin"), "Verified title of the page");
        //}
        
       
        [TestMethod()]
        public void AnyBarWins()
        {
            //0   1     2     3      4    5     6      7      8      9       10     11     12    13     14     15     16
            //7, 3Bar, 2Bar, 2Bar, 1Bar, 1Bar, 1Bar, Cherry, Blank, Blank, Blank, Blank, Blank, Blank, Blank, Blank, Blank

            int cred = 1;

            HomeController controller = new HomeController();
            int results = controller.CheckResult(1, 2, 3, cred);
            Assert.IsTrue(results == 5);

            cred = 2;
            results = controller.CheckResult(1, 2, 3, cred);
            Assert.IsTrue(results == 10);

            cred = 3;
            results = controller.CheckResult(1, 2, 3, cred);
            Assert.IsTrue(results == 15);
        }

        [TestMethod()]
        public void DoubleBarWins()
        {
            //0   1     2     3      4    5     6      7      8      9       10     11     12    13     14     15     16
            //7, 3Bar, 2Bar, 2Bar, 1Bar, 1Bar, 1Bar, Cherry, Blank, Blank, Blank, Blank, Blank, Blank, Blank, Blank, Blank

            int cred = 1;

            HomeController controller = new HomeController();
            int results = controller.CheckResult(2, 2, 2, cred);
            Assert.IsTrue(results == 50);

            cred = 2;
            results = controller.CheckResult(2, 3, 2, cred);
            Assert.IsTrue(results == 100);

            cred = 3;
            results = controller.CheckResult(3, 2, 2, cred);
            Assert.IsTrue(results == 150);

        }

        [TestMethod()]
        public void TripleBarWins()
        {
            //0   1     2     3      4    5     6      7      8      9       10     11     12    13     14     15     16
            //7, 3Bar, 2Bar, 2Bar, 1Bar, 1Bar, 1Bar, Cherry, Blank, Blank, Blank, Blank, Blank, Blank, Blank, Blank, Blank

            int cred = 1;

            HomeController controller = new HomeController();
            int results = controller.CheckResult(1, 1, 1, cred);
            Assert.IsTrue(results == 100);

            cred = 2;
            results = controller.CheckResult(1, 1, 1, cred);
            Assert.IsTrue(results == 200);

            cred = 3;
            results = controller.CheckResult(1, 1, 1, cred);
            Assert.IsTrue(results == 300);
        }

        [TestMethod()]
        public void SevenWins()
        {
            //0   1     2     3      4    5     6      7      8      9       10     11     12    13     14     15     16
            //7, 3Bar, 2Bar, 2Bar, 1Bar, 1Bar, 1Bar, Cherry, Blank, Blank, Blank, Blank, Blank, Blank, Blank, Blank, Blank

            int cred = 1;

            HomeController controller = new HomeController();
            int results = controller.CheckResult(0, 0, 0, cred);
            Assert.IsTrue(results == 300);

            cred = 2;
            results = controller.CheckResult(0, 0, 0, cred);
            Assert.IsTrue(results == 600);

            cred = 3;
            results = controller.CheckResult(0, 0, 0, cred);
            Assert.IsTrue(results == 1500);
        }

        //[TestMethod]
        //public void Index()
        //{
        //    TestControllerBuilder builder = new TestControllerBuilder();

        //    // Arrange
        //    HomeController controller = new HomeController();
        //    builder.InitializeController(controller);

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;
            
        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod()]
        //public void AddCredits()
        //{
        //    TestControllerBuilder builder = new TestControllerBuilder();

        //    HomeController controller = new HomeController();

        //    builder.InitializeController(controller);

        //    controller.AddCredit(1);
        //    Assert.IsNotNull(" ");
        //}

        //[TestMethod()]
        //public void GetFinalBalance()
        //{
        //    TestControllerBuilder builder = new TestControllerBuilder();

        //    HomeController controller = new HomeController();
        //    builder.InitializeController(controller);

        //    controller.GetFinalBalance();
        //    Assert.IsNotNull(" ");
        //}

        //[TestMethod()]
        //public void PlayGame()
        //{
        //    TestControllerBuilder builder = new TestControllerBuilder();

        //    HomeController controller = new HomeController();

        //    builder.InitializeController(controller);

        //    System.Web.Mvc.ActionResult results = controller.PlayGame(new Int32[] { 0, 1, 1 });

        //    Assert.IsNotNull(results);
        //}

    }
}
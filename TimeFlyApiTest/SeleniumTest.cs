using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace TimeFlyApiTest
{
    [TestClass]
    public class SeleniumTest
    {
        [TestMethod]
        public void TakeScreenshot()
        {
            string url = "https://3w.huanqiu.com/a/6b1c64/7N5nhVyjRkI?agt=20&tt_group_id=6696537495833674244";
            string image = @"test.png";
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl(url);
            var ss = driver.GetScreenshot();
            ss.SaveAsFile(image, OpenQA.Selenium.ScreenshotImageFormat.Png);
            driver.Close();
        }

        [TestMethod]
        public void UnitTestShouldAlwaysWorkTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void OnePlusTwoEqualThreeTest()
        {
            Assert.IsTrue(true);
        }
    }
}

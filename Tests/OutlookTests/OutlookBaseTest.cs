using Core.UI;
using NUnit.Framework;

namespace Tests.OutlookTests
{
    public class OutlookBaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Browser.Instance.GoToUrl("https://account.microsoft.com/account");
            Browser.Instance.GetDriver().Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            Browser.Instance.Quit();
        }
    }
}
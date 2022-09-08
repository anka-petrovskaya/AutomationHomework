using NUnit.Framework;

namespace Outlook.Tests
{
    public class BaseTest
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
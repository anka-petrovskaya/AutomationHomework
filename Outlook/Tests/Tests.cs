using NUnit.Framework;
using Outlook.Pages;
using System.Linq;
using System.Threading;

namespace Outlook.Tests
{
    public class Tests : BaseTest
    {
        [OneTimeSetUp]
        public void Login()
        {
            LoginPage.Instance.Login(UserCredentials.HannaUser);
            Browser.Instance.SwitchToNextTab();
            Assert.IsTrue(MainPage.Instance.CreateMessageButton.IsVisible());
        }

        [Test]
        [Order(1)]
        public void SaveAsDraft()
        {
            string subject = RandomHelper.GetString(9);
            var email = RandomHelper.GetEmail();
            MainPage.Instance.FillDraftMessageInfo(email, subject, "Hello World!");
            MainPage.Instance.SaveCurrentAsDraft();
            Assert.IsTrue(MainPage.Instance.CheckMessageInFolder("Черновики", subject), "No new draft message was found");

            var IinfoIsCorrect = MainPage.Instance.VerifyAllMessageFields(email, subject, "Hello World!");
            Assert.IsTrue(IinfoIsCorrect, "Info is incorrect");
        }

        [Test]
        [Order(2)]
        public void SendMessage()
        {
            var subject = MainPage.Instance.CreateNewDraftsIfNoAny();
            MainPage.Instance.SendMessage(subject);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(MainPage.Instance.CheckMessageInFolder("Отправленные", subject), "The message was not found");
                Assert.IsTrue(MainPage.Instance.CheckMessageInFolder("Черновики", subject, false), "the message is still in the folder");
            });
        }

        [Test]
        [Order(3)]
        public void DeleteDraft()
        {
            var subject = MainPage.Instance.CreateNewDraftsIfNoAny();
            MainPage.Instance.FollowMessage("Черновики", subject);
            MainPage.Instance.DeleteDraft(subject);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(MainPage.Instance.CheckMessageInFolder("Удаленные", subject), "The message was not found");
                Assert.IsTrue(MainPage.Instance.CheckMessageInFolder("Черновики", subject, false), "The message is still in the folder");
            });
        }

        [Test]
        [Order(4)]
        public void OpenDraftWithDoubleClick()
        {
            var subject = MainPage.Instance.CreateNewDraftsIfNoAny();
            MainPage.Instance.FollowMessage("Черновики", subject);
            var before = Browser.Instance.GetDriver().WindowHandles.Count;
            MainPage.Instance.MessagePreview(subject).DoubleClick();
            var after = Browser.Instance.GetDriver().WindowHandles.Count;
            Assert.IsTrue(after > before, "New window not opened");
        }

        [Test]
        [Order(7)]
        public void CleanUpFolder()
        {
            var subject = MainPage.Instance.CreateNewDraftsIfNoAny();
            MainPage.Instance.CleanUpFolder("Черновики");
            Assert.Multiple(() =>
            {
                Assert.IsTrue(MainPage.Instance.CheckMessageInFolder("Удаленные", subject), "the message is still in the folder");
                Assert.IsTrue(MainPage.Instance.CheckMessageInFolder("Черновики", subject, false), "The message was not found");
            });
        }

        [Test]
        [Order(8)]
        public void ExecuteJsHighlightScript()
        {
            var subject = MainPage.Instance.CreateNewDraftsIfNoAny();
            var allSubjects = MainPage.Instance.AllMessages().GetListElements().Select(x => x.Text).ToList();
            foreach (var subj in allSubjects)
            {
                MainPage.Instance.MessagePreview(subj).ExecuteJsScript(TestData.HighlightScriptLine);
                Thread.Sleep(1500);
            }
        }

        [OneTimeTearDown]
        public void Logout()
        {
            MainPage.Instance.LogOff();
        }
    }
}
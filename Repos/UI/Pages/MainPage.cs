using Core.UI;
using OpenQA.Selenium;
using System;
using System.Linq;
using Utils;

namespace Repos.UI.Pages
{
    public class MainPage : BasePage
    {
        private static MainPage mainPage;
        public static MainPage Instance => mainPage ??= new MainPage();

        #region Elements
        //folder actions
        public By CreateMessageButton => By.XPath("//span[text()='Создать сообщение']");
        public By FoldersMenuOption(string value) => By.XPath($"//div[@data-app-section='NavigationPane']//span[text()='{value}']");
        private By FolderSelected(string value) => By.XPath($"//div[@data-app-section='NavigationPane']//span[text()='{value}']/../span[@class='screenReaderOnly']");
        public By MessagePreview(string subject) => By.XPath($"//div[@aria-label='Список сообщений']//span[text()='{subject}']");
        private By FirstDraftMessageSubject => By.XPath("(//div[contains(@aria-label, '[Черновик]')]//span[@title])[2]");
        public By AllMessages() => By.XPath("//div[@class='xfjq3 pz2Jt MtC_r jYIx5']/span");
        private By FolderCounter(string folder) => By.XPath($"(//div[@data-app-section='NavigationPane']//span[text()='{folder}']/..//span)[5]");
        private By CleanUpFolder() => By.XPath($"//span[text()='Очистить папку']/ancestor::button");
        //message template
        private By SendEmailInput => By.XPath("//div[@id='ReadingPaneContainerId']//div[@role='textbox']");
        private By SendSubjectField => By.XPath("//div//input[@placeholder='Добавьте тему']");
        public By SendBodyField => By.XPath("//div[@id='ReadingPaneContainerId']//div[contains(@aria-label,'Текст сообщения')]/div");
        private By DraftEmailInputValue => By.XPath("//div[@role='textbox']//span[@class='recipientClass']/*/span[1]");
        //message actions
        private By MessageActionsMenu => By.XPath("//*[contains(@class, 'CommandBar')]//div[contains(@class, 'overflowButton')]");
        private By MessageOption(string action) => By.XPath($"//ul[contains(@class, 'ContextualMenu')]//button[@name='{action}']");
        private By SendEmailButton => By.XPath("//button[@aria-label='Другие параметры отправки']/../button");
        private By DeleteEmailButton() => By.XPath($"//i[@data-icon-name='Delete']/ancestor::button");
        //private By TrashIcon() => By.XPath($"//i[@data-icon-name='DeleteRegular']//ancestor::button");
        private By ApproveDeleteButton() => By.XPath($"//button[@id='ok-1']");
        //private By EmailDeletedLabel() => By.XPath($"//span[@title='Удалено']");
        //private By CancelDeletionButton => By.XPath("//button[@title='Отменить']");
        private By SelectMessagCheckBox => By.XPath("//div[@aria-label='Выбрать сообщение']");
        //logout
        private By LogOffMenu => By.XPath("//div[@id='O365_MainLink_MePhoto']");
        private By LogOffButton => By.XPath("//a[@id='mectrl_body_signOut']");
        #endregion

        #region Messages Flow
        public void FillDraftMessageInfo(string address, string subject, string body)
        {
            CreateMessageButton.Click();
            SendEmailInput.SendKeys(address);
            SendSubjectField.SendKeys(subject);
            SendBodyField.SendKeys(body);
        }
        public void SaveCurrentAsDraft()
        {
            var before = GetMessagesCount("Черновики");
            MessageActionsMenu.Click();
            MessageOption("Сохранить черновик").Click();
            Wait.Until(() => GetMessagesCount("Черновики") != before);
        }
        public string CreateNewDraftsIfNoAny(int desired = 1)
        {
            string subj = string.Empty;
            var mesCount = 0;
            FollowFolder("Черновики");
            try
            {
                mesCount = AllMessages().GetListElements().Count();
            }
            catch (Exception) { }
            if (mesCount < desired)
            {
                for (int i = 0; i < desired - mesCount; i++)
                {
                    subj = RandomHelper.GetString(9);
                    FillDraftMessageInfo(RandomHelper.GetEmail(), subj, RandomHelper.GetString(10));
                    SaveCurrentAsDraft();
                }
            }
            else subj = AllMessages().GetListElements().First().Text;
            return subj;
        }
        public bool VerifyAllMessageFields(string address, string subject, string body)
        {
            MessagePreview(subject).Click();
            var recipientIsOk = DraftEmailInputValue.GetText() == address;
            var addedSubjectIsOk = SendSubjectField.GetAttribute("value") == subject;
            var addedBodyIsOk = SendBodyField.GetText() == body;
            return recipientIsOk && addedSubjectIsOk && addedBodyIsOk;
        }
        public void SendMessage(string subject)
        {
            var draftsBefore = GetMessagesCount("Черновики");
            FollowFolder("Черновики");
            MessagePreview(subject).Click();
            SendEmailButton.Click();
            Wait.Until(() => GetMessagesCount("Черновики") != draftsBefore);
        }
        public void SendMessageWithAttachment(string subject)
        {
            var draftsbefore = GetMessagesCount("Черновики");
            FollowFolder("Черновики");
            MessagePreview(subject).Click();
            SelectMessagCheckBox.HoverMouseOver();

        }
        public void DeleteFewMessagesWithCheckBoxes(string subject)
        {
            var draftsbefore = GetMessagesCount("Черновики");
            FollowFolder("Черновики");
            MessagePreview(subject).Click();
            SelectMessagCheckBox.HoverMouseOver();
            SelectMessagCheckBox.Click();
        }

        public void DeleteDraft(string subject)
        {
            var draftsBefore = GetMessagesCount("Черновики");
            FollowMessage("Черновики", subject);
            DeleteEmailButton().Click();
            if (ApproveDeleteButton().IsVisible())
                ApproveDeleteButton().Click();

            Wait.Until(() => GetMessagesCount("Черновики") != draftsBefore);
        }
        public void CleanUpFolder(string folder)
        {
            FollowFolder(folder);
            Browser.Instance.ReloadPage();
            CleanUpFolder().Click();
            ApproveDeleteButton().Click();
        }

        #endregion

        #region Folders View
        public void FollowFolder(string folder) => Wait.RetryUntilTrue(() => FoldersMenuOption(folder).Click(), () => FolderSelected(folder).IsVisible());
        public void FollowMessage(string folder, string subject)
        {
            FollowFolder(folder);
            MessagePreview(subject).Click();
        }
        public string GetMessagesCount(string folder) => FolderCounter(folder).GetText();
        public bool CheckMessageInFolder(string folder, string subject, bool isVisible = true)
        {
            FollowFolder(folder);
            return isVisible ? MessagePreview(subject).IsVisible() : MessagePreview(subject).IsInvisible();
        }
        #endregion

        public void LogOff()
        {
            LogOffMenu.Click();
            LogOffButton.Click();
        }
    }
}
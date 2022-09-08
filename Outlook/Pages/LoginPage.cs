using OpenQA.Selenium;

namespace Outlook.Pages
{
    public class LoginPage : BasePage
    {
        private static LoginPage loginPage;
        public static LoginPage Instance => loginPage ??= new LoginPage();
        public By SignInButton = By.XPath("//a[@id='signinlinkhero']");
        public By EmailInputField = By.Name("loginfmt");
        public By SubmitButton = By.XPath("//input[@type='submit']");
        public By PasswordInputField = By.XPath("//input[@name='passwd']");
        public By ShortMenu = By.XPath("//button[@id='O365_MainLink_NavMenu']");
        public By MainMenuButton(string name) => By.XPath($"//*[@id='appLauncherMainView']//a[@aria-label='{name}']");

        public void Login(string email, string password)
        {
            SignInButton.Click();
            EmailInputField.SendKeys(email);
            SubmitButton.Click();
            PasswordInputField.SendKeys(password);
            SubmitButton.Click();
            SubmitButton.Click();
            ShortMenu.Click();
            MainMenuButton("Outlook").Click();
        }
    }
}
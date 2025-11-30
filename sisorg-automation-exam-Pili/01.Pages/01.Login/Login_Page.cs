using OpenQA.Selenium;

namespace sisorg_automation_exam_MP.Pages.Login
{
    public class Login_Page : Login_Elements
    {
        public Login_Page(IWebDriver driver) => Driver = driver;

        public bool ExistsLoginBox()
        {
            return LoginBox.Displayed;
        }

        public void SetUserName(string userName)
        {
            TxtUserName.Clear();
            TxtUserName.SendKeys(userName);
        }

        public void SetPassword(string password)
        {
            TxtPassword.Clear();
            TxtPassword.SendKeys(password);
        }

        public bool ExistsErrorMessage()
        {
            return DivErrorMessage.Displayed;
        }

        public bool ExistsErrorMessage(out string errorMessege)
        {
            try
            {
                bool exists = DivErrorMessage.Displayed;
                errorMessege = exists ? DivErrorMessage.Text : string.Empty;
                return DivErrorMessage.Displayed;
            }
            catch (NoSuchElementException)
            {
                errorMessege = string.Empty;
                return false;
            }
        }

        public void ClickLoginButton()
        {
            BtnLogin.Click();
        }

    }
}

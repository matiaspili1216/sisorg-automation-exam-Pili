using OpenQA.Selenium;

namespace sisorg_automation_exam_MP.Pages.Login
{
    public class Edicion_Page : Edicion_Elements
    {
        public Edicion_Page(IWebDriver driver) => Driver = driver;

        public bool ExistsPage(out string title)
        {
            bool result = PageTitle.Displayed;
            title = result ? PageTitle.Text : string.Empty;
            return result;
        }
        public bool IsClientIDEnable() => TxtClientId.Enabled;
        public string GetClientID() => TxtClientId.GetAttribute("value");

        public string GetName() => TxtName.GetAttribute("value");
        public string GetEmail() => TxtEmail.GetAttribute("value");
        public string GetPhone() => TxtPhone.GetAttribute("value");
        public string GetStatus() => DdlStatus.SelectedOption.Text;

        public void SetName(string name)
        {
            TxtName.Clear();
            TxtName.SendKeys(name);
        }

        public void SetEmail(string email)
        {
            TxtEmail.Clear();
            TxtEmail.SendKeys(email);
        }

        public void SetPhone(string phone)
        {
            TxtPhone.Clear();
            TxtPhone.SendKeys(phone);
        }

        public void SelectStatus(string status)
        {
            DdlStatus.SelectByText(status);
        }

        public void DeselectStatus()
        {
            DdlStatus.SelectByIndex(0);
        }

        public void ClickBtnSave()
        {
            BtnSave.Click();
        }

        public void ClickBtnCancel()
        {
            BtnCancel.Click();
        }

        public void ClickBtnBack()
        {
            BtnBack.Click();
        }

        public bool ExistsValidationErrors(out List<string> errors)
        {
            if (DivValidationErrors.Displayed)
            {
                errors = DivValidationErrorsList.Select(e => e.Text).ToList();
                return true;
            }
            else
            {
                errors = new List<string>();
                return false;
            }
        }

        public bool ExistsSuccessMessage(out string successMessage)
        {
            if(DivSuccessMessage.Displayed)
            {
                successMessage = DivSuccessMessage.Text;
                return true;
            }
            else
            {
                successMessage = string.Empty;
                return false;
            }
        }
    }
}

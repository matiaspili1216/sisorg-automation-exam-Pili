using OpenQA.Selenium;

using sisorg_automation_exam_MP.Pages.Login;

using System.Configuration;

namespace sisorg_automation_exam_MP.Functions
{
    public class Login_Functions
    {
        public Login_Page LPage;

        public Login_Functions(IWebDriver driver) => LPage = new Login_Page(driver);

        public bool Login(string userName, string password, out string messege, out string errorMessege)
        {
            if(!LPage.ExistsLoginBox())
            {
                messege = "No se encontraron los campos del Login.";
                errorMessege = "";
                return false;
            }

            LPage.SetUserName(userName);
            LPage.SetPassword(password);
            LPage.ClickLoginButton();

            bool existeError = LPage.ExistsErrorMessage(out errorMessege);

            messege = existeError ? $"Se muestra un mensaje de error al iniciar sesión." : "Login exitoso.";
            return !existeError;
        }

        public bool Login()
        {
            if (!LPage.ExistsLoginBox())
            {
                return false;
            }

            LPage.SetUserName(ConfigurationManager.AppSettings["Usuario"] ?? "admin");
            LPage.SetPassword(ConfigurationManager.AppSettings["Contraseña"] ?? "admin123");
            LPage.ClickLoginButton();

            return true;
        }
    }
}

using sisorg_automation_exam_MP.Functions;

using System.Configuration;

namespace sisorg_automation_exam_MP.Tests
{
    [TestClass]
    public class Login_Test : Base_Test
    {
        Login_Functions LoginFunctions;

        public Login_Test() : base() { LoginFunctions = new Login_Functions(Driver); }

        [TestMethod]
        [TestProperty("TestExecutionName", "Login_Credenciales_Correctas"), TestProperty("TestExecutionCategory", "Login")]
        public void Login_Credenciales_Correctas()
        {
            string usuario = ConfigurationManager.AppSettings["Usuario"] ?? "admin";
            string contraseña = ConfigurationManager.AppSettings["Contraseña"] ?? "admin123";
            bool result = LoginFunctions.Login(usuario, contraseña, out string messege, out string errorMessege);

            Assert.IsTrue(result, $"{messege}{(string.IsNullOrEmpty(errorMessege) ? "" : $" - {errorMessege}")}");
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Login_Credenciales_Incorrectas"), TestProperty("TestExecutionCategory", "Login")]
        public void Login_Credenciales_Incorrectas()
        {
            bool result = LoginFunctions.Login("admin", "admin", out _, out string errorMessege);

            Assert.IsFalse(result, $"No se muestran validaciones, con credenciales incorrectas");
            Assert.AreEqual("Usuario o contraseña incorrectos. Por favor, intente nuevamente.", errorMessege);
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Login_Campos_Vacíos_Usuario"), TestProperty("TestExecutionCategory", "Login")]
        public void Login_Campos_Vacíos_Usuario()
        {
            bool result = LoginFunctions.Login("", "", out _, out string errorMessege);

            Assert.IsFalse(result, $"No se muestran validaciones, al no completar Usurio");
            Assert.AreEqual("El campo Usuario es requerido.", errorMessege);
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Login_Campos_Vacíos_Contraseña"), TestProperty("TestExecutionCategory", "Login")]
        public void Login_Campos_Vacíos_Contraseña()
        {
            bool result = LoginFunctions.Login("usuario", "", out _, out string errorMessege);

            Assert.IsFalse(result, $"No se muestran validaciones, al no completar Contraseña");
            Assert.AreEqual("El campo Contraseña es requerido.", errorMessege);
        }
    }
}

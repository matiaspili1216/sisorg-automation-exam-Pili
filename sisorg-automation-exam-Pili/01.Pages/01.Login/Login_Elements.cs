using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisorg_automation_exam_MP.Pages.Login
{
    public class Login_Elements
    {
        protected IWebDriver Driver;

        /// <summary>
        /// Box con los campos necesarios para ingreso de Usuario y Contraseña
        /// </summary>
        public IWebElement LoginBox { get { return Driver.FindElement(By.ClassName("login-box")); } }

        /// <summary>
        /// Input para ingreso de Usuario
        /// </summary>
        public IWebElement TxtUserName { get { return LoginBox.FindElement(By.Id("txtUserName")); } }

        /// <summary>
        /// Input para ingreso de Contraseña
        /// </summary>
        public IWebElement TxtPassword { get { return LoginBox.FindElement(By.Id("txtPassword")); } }

        /// <summary>
        /// Div para mostrar mensajes de error
        /// </summary>
        public IWebElement DivErrorMessage { get { return LoginBox.FindElement(By.Id("divErrorMessage")); } }

        /// <summary>
        /// Botón para iniciar sesión
        /// </summary>
        public IWebElement BtnLogin { get { return LoginBox.FindElement(By.Id("btnLogin")); } }
    }
}

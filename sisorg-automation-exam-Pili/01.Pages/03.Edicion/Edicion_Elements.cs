using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System.Collections.ObjectModel;

namespace sisorg_automation_exam_MP.Pages.Login
{
    public class Edicion_Elements
    {
        protected IWebDriver Driver;

        /// <summary>
        /// H2 con el título de la página
        /// </summary>
        public IWebElement PageTitle { get { return Driver.FindElement(By.ClassName("page-title")); } }

        /// <summary>
        /// Formulario de búsqueda
        /// </summary>
        public IWebElement FrmEdit { get { return Driver.FindElement(By.Id("frmEdit")); } }

        /// <summary>
        /// Input que muestra el ID del cliente
        /// </summary>
        public IWebElement TxtClientId { get { return FrmEdit.FindElement(By.Id("txtClientId")); } }

        /// <summary>
        /// Input para la edición del nombre
        /// </summary>
        public IWebElement TxtName { get { return FrmEdit.FindElement(By.Id("txtName")); } }

        /// <summary>
        /// Input para la edición del correo
        /// </summary>
        public IWebElement TxtEmail { get { return FrmEdit.FindElement(By.Id("txtEmail")); } }

        /// <summary>
        /// Input para la edición del teléfono
        /// </summary>
        public IWebElement TxtPhone { get { return FrmEdit.FindElement(By.Id("txtPhone")); } }

        /// <summary>
        /// Dropdown para selección del estado a buscar
        /// </summary>
        public SelectElement DdlStatus { get { return new SelectElement(FrmEdit.FindElement(By.Id("ddlStatus"))); } }

        /// <summary>
        /// Botón para guardar los cambios realizados
        /// </summary>
        public IWebElement BtnSave { get { return FrmEdit.FindElement(By.Id("btnSave")); } }

        /// <summary>
        /// Botón para cancelar la edición
        /// </summary>
        public IWebElement BtnCancel { get { return FrmEdit.FindElement(By.Id("btnCancel")); } }

        /// <summary>
        /// Botón para volver a la página de búsqueda
        /// </summary>
        public IWebElement BtnBack { get { return FrmEdit.FindElement(By.Id("btnBack")); } }

        /// <summary>
        /// Contenedor de los mensajes de error de validación
        /// </summary>
        public IWebElement DivValidationErrors { get { return FrmEdit.FindElement(By.Id("divValidationErrors")); } }

        public ReadOnlyCollection<IWebElement> DivValidationErrorsList { get { return DivValidationErrors.FindElements(By.TagName("li")); } }


        /// <summary>
        /// Contenedor del mensaje de éxito
        /// </summary>
        public IWebElement DivSuccessMessage { get { return Driver.FindElement(By.Id("divSuccessMessage")); } }
    }
}
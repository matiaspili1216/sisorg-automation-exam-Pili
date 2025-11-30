using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisorg_automation_exam_MP.Pages.Login
{
    public class Busqueda_Elements
    {
        protected IWebDriver Driver;

        /// <summary>
        /// Label con el nombre de usuario logueado
        /// </summary>
        public IWebElement LblUserName => Driver.FindElement(By.Id("lblUserName"));

        /// <summary>
        /// Link de acceso a la página de Reportes
        /// </summary>
        public IWebElement LnkReports => Driver.FindElement(By.Id("lnkReports"));

        /// <summary>
        /// H2 con el título de la página
        /// </summary>
        public IWebElement PageTitle { get { return Driver.FindElement(By.ClassName("page-title")); } }

        #region Formulario Búsqueda

        /// <summary>
        /// Formulario de búsqueda
        /// </summary>
        public IWebElement FrmSearch { get { return Driver.FindElement(By.Id("frmSearch")); } }

        /// <summary>
        /// Input para ingreso del nombre a buscar
        /// </summary>
        public IWebElement TxtSearchName { get { return FrmSearch.FindElement(By.Id("txtSearchName")); } }

        /// <summary>
        /// Input para ingreso del correo a buscar
        /// </summary>
        public IWebElement TxtSearchEmail { get { return FrmSearch.FindElement(By.Id("txtSearchEmail")); } }

        /// <summary>
        /// Dropdown para selección del estado a buscar
        /// </summary>
        public SelectElement DdlSearchStatus { get { return new SelectElement(FrmSearch.FindElement(By.Id("ddlSearchStatus"))); } }

        /// <summary>
        /// Botón para iniciar la búsqueda
        /// </summary>
        public IWebElement BtnSearch { get { return FrmSearch.FindElement(By.Id("btnSearch")); } }

        /// <summary>
        /// Botón para limpiar los campos de búsqueda
        /// </summary>
        public IWebElement BtnClear { get { return FrmSearch.FindElement(By.Id("btnClear")); } }
        #endregion

        #region Resultados

        /// <summary>
        /// Tabla con los resultados de la búsqueda
        /// </summary>
        public IWebElement TableResult { get { return Driver.FindElement(By.Id("gvResults")); } }

        /// <summary>
        /// Filas de resultados en la tabla (sin incluir la fila de encabezados)
        /// </summary>
        public ReadOnlyCollection<IWebElement> TableResultRows => TableResult.FindElements(By.TagName("tr")).Skip(1).ToList().AsReadOnly();

        /// <summary>
        /// Fila de resultado en la tabla según el índice especificado
        /// </summary>
        /// <param name="index">Indice de la Fila</param>
        /// <returns></returns>
        public IWebElement TableResultRow(int index) => TableResultRows[index];

        public ReadOnlyCollection<IWebElement> TableResultRowValues(int index) => TableResultRow(index).FindElements(By.TagName("td"));

        /// <summary>
        /// Botón Editar para la fila específicada
        /// </summary>
        /// <param name="index">Indice de la Fila</param>
        /// <returns></returns>
        public IWebElement BtnEdit(int index) => TableResultRows[index].FindElement(By.ClassName("btn-primary"));

        /// <summary>
        /// Botón Editar para la fila específicada mediante un elemento IWebElement
        /// </summary>
        /// <param name="row">IWebElement de la fila</param>
        /// <returns></returns>
        public IWebElement BtnEdit(IWebElement row) => row.FindElement(By.ClassName("btn-primary"));

        #endregion

        /// <summary>
        /// Div que indica que no se encontraron resultados
        /// </summary>
        public IWebElement DivNoResults { get { return Driver.FindElement(By.Id("divNoResults")); } }
    }
}
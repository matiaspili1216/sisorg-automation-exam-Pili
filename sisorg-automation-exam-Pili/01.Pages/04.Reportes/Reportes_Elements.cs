using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System.Collections.ObjectModel;

namespace sisorg_automation_exam_MP.Pages.Login
{
    public class Reportes_Elements
    {
        protected IWebDriver Driver;

        /// <summary>
        /// H2 con el título de la página
        /// </summary>
        public IWebElement PageTitle { get { return Driver.FindElement(By.ClassName("page-title")); } }

        #region Formulario Filtros

        /// <summary>
        /// Formulario de búsqueda
        /// </summary>
        public IWebElement FrmReportFilters { get { return Driver.FindElement(By.Id("frmReportFilters")); } }

        /// <summary>
        /// Input para ingreso del nombre a buscar
        /// </summary>
        public IWebElement TxtDateFrom { get { return FrmReportFilters.FindElement(By.Id("txtDateFrom")); } }

        /// <summary>
        /// Input para ingreso del correo a buscar
        /// </summary>
        public IWebElement TxtDateTo { get { return FrmReportFilters.FindElement(By.Id("txtDateTo")); } }

        /// <summary>
        /// Dropdown para selección del estado a buscar
        /// </summary>
        public SelectElement DdlReportStatus { get { return new SelectElement(FrmReportFilters.FindElement(By.Id("ddlReportStatus"))); } }

        /// <summary>
        /// Botón para iniciar la búsqueda
        /// </summary>
        public IWebElement BtnGenerateReport { get { return FrmReportFilters.FindElement(By.Id("btnGenerateReport")); } }

        /// <summary>
        /// Botón para limpiar los campos de búsqueda
        /// </summary>
        public IWebElement BtnExportCSV { get { return FrmReportFilters.FindElement(By.Id("btnExportCSV")); } }
        #endregion

        #region Resultados

        public IWebElement DivReportMessage { get { return Driver.FindElement(By.Id("divReportMessage")); } }

        /// <summary>
        /// Tabla con los resultados de la búsqueda
        /// </summary>
        public IWebElement TableResult { get { return Driver.FindElement(By.Id("gvReport")); } }

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

        #endregion
    }
}
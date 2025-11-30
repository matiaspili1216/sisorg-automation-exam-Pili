using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

using sisorg_automation_exam_MP._00.Tools;
using sisorg_automation_exam_MP.Functions;
using sisorg_automation_exam_MP.Functions.DTOs;

using System.Configuration;

namespace sisorg_automation_exam_MP.Tests
{
    [TestClass]
    public class Reportes_Test : Base_Test
    {
        Reportes_Functions ResportesFunctions;

        public Reportes_Test() : base() { ResportesFunctions = new Reportes_Functions(Driver); }

        private void FirstStep()
        {

            new Login_Functions(Driver).Login();
            new Busqueda_Functions(Driver).NavigateToReports();
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Reportes_TituloPagina"), TestProperty("TestExecutionCategory", "Reportes")]
        public void Reportes_TituloPagina()
        {
            FirstStep();

            bool result = ResportesFunctions.ExistsReportesPage(out string title);

            Assert.IsTrue(result, "No se encontró la página de Búsqueda de Clientes.");
            Assert.AreEqual("Reporte de Clientes", title, $"El título de la página no es el esperado.");
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Reportes_GenerarReporte"), TestProperty("TestExecutionCategory", "Reportes")]
        public void Reportes_GenerarReporte()
        {
            FirstStep();

            ResportesFunctions.GenerateReport(DateTime.Now.AddMonths(-1).ToShortDateString(), DateTime.Now.ToShortDateString());

            List<Cliente> resultados = ResportesFunctions.GetTableResults();

            bool result = ResportesFunctions.IsDivReportMessageDisplayed(out string reportMessage);

            Assert.IsTrue(result, "No se muestra el mensaje de reporte generado.");
            Assert.AreEqual($"Reporte generado correctamente. Registros encontrados: {resultados.Count}", reportMessage, "El mensaje de 'Reporte generado correctamente' no es el esperado");
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Reportes_ExportCSV"), TestProperty("TestExecutionCategory", "Reportes")]
        public void Reportes_ExportCSV()
        {
            FirstStep();

            ResportesFunctions.ExportCSV(DateTime.Now.AddMonths(-1).ToShortDateString(), DateTime.Now.ToShortDateString());

            bool downloadResult = UtilsMethods.ValidateDownloadFile(DownloadDirectory, @"Reporte_Clientes_*.csv", out string fileName);

            Assert.IsTrue(downloadResult, "La descarga no se realizó correctamente");

            List<Cliente> resultados = ResportesFunctions.GetTableResults();

            bool result = ResportesFunctions.IsDivReportMessageDisplayed(out string reportMessage);

            Assert.IsTrue(result, "No se muestra el mensaje de archivo exportado.");

            var re_reportName = new System.Text.RegularExpressions.Regex(@"^Archivo CSV exportado exitosamente: Reporte_Clientes_[A-Za-z0-9]+\.csv$");

            StringAssert.Matches(reportMessage, re_reportName);

            Assert.AreEqual($"Archivo CSV exportado exitosamente: {fileName}", reportMessage);
        }
    }
}

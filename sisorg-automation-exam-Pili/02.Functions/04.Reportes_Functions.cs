using OpenQA.Selenium;

using sisorg_automation_exam_MP.Functions.DTOs;
using sisorg_automation_exam_MP.Pages.Login;

namespace sisorg_automation_exam_MP.Functions
{
    public class Reportes_Functions
    {
        public Reportes_Page BPage;

        public Reportes_Functions(IWebDriver driver) => BPage = new Reportes_Page(driver);

        public bool ExistsReportesPage(out string title) => BPage.ExistsPage(out title);

        public void GenerateReport(string dateFrom = "", string dateTo = "", string status = "")
        {
            if (!string.IsNullOrEmpty(dateFrom)) { BPage.SetDateFrom(dateFrom); }
            if (!string.IsNullOrEmpty(dateTo)) { BPage.SetDateTo(dateTo); }
            if (!string.IsNullOrEmpty(status)) { BPage.SelectStatus(status); }

            BPage.ClickBtnGenerateReport();
        }

        public void ExportCSV(string dateFrom = "", string dateTo = "", string status = "")
        {
            GenerateReport(dateFrom, dateTo, status);

            BPage.ClickBtnExportCSV();
        }

        public bool IsTableResultDisplayed() => BPage.IsTableResultDisplayed();
        public bool IsDivReportMessageDisplayed(out string reportMessage) => BPage.IsDivReportMessageDisplayed(out reportMessage);

        public List<Cliente> GetTableResults()
        {
            if (!IsTableResultDisplayed()) { throw new Exception("La tabla de resultados no está visible.");}

            List<Cliente> results = [];

            for (int i = 0; i < BPage.GetTableRowCount(); i++)
            {
                List<string> values = BPage.GetRowValues(i);

                var cliente = new Cliente
                (
                    values.ElementAt(0),
                    values.ElementAt(1),
                    values.ElementAt(2),
                    values.ElementAt(3),
                    values.ElementAt(4),
                    values.ElementAt(5)
                );

                results.Add(cliente);
            }

            return results;
        }
    }
}
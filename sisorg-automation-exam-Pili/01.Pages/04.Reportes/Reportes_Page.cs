using OpenQA.Selenium;

namespace sisorg_automation_exam_MP.Pages.Login
{
    public class Reportes_Page : Reportes_Elements
    {
        public Reportes_Page(IWebDriver driver) => Driver = driver;

        public bool ExistsPage(out string title)
        {
            bool result = PageTitle.Displayed;
            title = result ? PageTitle.Text : string.Empty;
            return result;
        }

        #region Filtros

        public void SetDateFrom(string dateFrom)
        {
            TxtDateFrom.Clear();
            TxtDateFrom.SendKeys(dateFrom);
        }

        public void SetDateTo(string dateTo)
        {
            TxtDateTo.Clear();
            TxtDateTo.SendKeys(dateTo);
        }

        public void SelectStatus(string status)
        {
            DdlReportStatus.SelectByText(status);
        }

        public void ClickBtnGenerateReport()
        {
            BtnGenerateReport.Click();
        }

        public void ClickBtnExportCSV()
        {
            BtnExportCSV.Click();
        }

        #endregion

        #region Resultado de filtros

        public bool IsDivReportMessageDisplayed(out string reportMessage)
        {
            bool result = DivReportMessage.Displayed;
            reportMessage = result ? DivReportMessage.Text.Trim() : string.Empty;
            return result;
        }

        public bool IsTableResultDisplayed() => TableResult.Displayed;

        public int GetTableRowCount() => TableResultRows.Count;

        public List<string> GetRowValues(int rowIndex)
        {
            var rowValues = TableResultRowValues(rowIndex);

            return rowValues.Select(td => td.Text.Trim()).ToList();
        }

        #endregion
    }
}
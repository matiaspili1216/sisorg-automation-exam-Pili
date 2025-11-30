using OpenQA.Selenium;

namespace sisorg_automation_exam_MP.Pages.Login
{
    public class Busqueda_Page : Busqueda_Elements
    {
        public Busqueda_Page(IWebDriver driver) => Driver = driver;

        public string GetLoggedUserName() => LblUserName.Text;

        public void ClickLnkReports() => LnkReports.Click();

        public bool ExistsPage(out string title)
        {
            bool result = PageTitle.Displayed;
            title = result ? PageTitle.Text : string.Empty;
            return result;
        }

        #region Búsqueda

        public void SetSearchName(string searchName)
        {
            TxtSearchName.Clear();
            TxtSearchName.SendKeys(searchName);
        }

        public void SetSearchEmail(string searchEmail)
        {
            TxtSearchEmail.Clear();
            TxtSearchEmail.SendKeys(searchEmail);
        }

        public void SelectStatus(string status)
        {
            DdlSearchStatus.SelectByText(status);
        }

        public void ClickBtnSearch()
        {
            BtnSearch.Click();
        }

        public void ClickBtnClear()
        {
            BtnClear.Click();
        }

        #endregion

        #region Resultado búsqueda

        public bool IsTableResultDisplayed() => TableResult.Displayed;

        public bool IsDivNoResultsDisplayed() => DivNoResults.Displayed;

        public int GetTableRowCount() => TableResultRows.Count;

        public List<string> GetRowValues(int rowIndex)
        {
            var rowValues = TableResultRowValues(rowIndex);

            return rowValues.Select(td => td.Text.Trim()).ToList();
        }

        public void AccessToEdit(int rowIndex)
        {
            BtnEdit(rowIndex).Click();
        }

        #endregion

    }
}

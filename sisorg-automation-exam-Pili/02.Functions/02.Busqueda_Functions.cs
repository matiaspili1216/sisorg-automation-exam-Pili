using OpenQA.Selenium;

using sisorg_automation_exam_MP.Functions.DTOs;
using sisorg_automation_exam_MP.Pages.Login;

namespace sisorg_automation_exam_MP.Functions
{
    public class Busqueda_Functions
    {
        public Busqueda_Page BPage;

        public Busqueda_Functions(IWebDriver driver) => BPage = new Busqueda_Page(driver);

        public string GetLoggedUserName() => BPage.GetLoggedUserName().Split(':')[1].Trim();

        public void NavigateToReports() => BPage.ClickLnkReports();

        public bool ExistsBusquedaPage(out string title) => BPage.ExistsPage(out title);

        public void Search(string name = "", string email = "", string status = "")
        {
            if (!string.IsNullOrEmpty(name)) { BPage.SetSearchName(name); }
            if (!string.IsNullOrEmpty(email)) { BPage.SetSearchEmail(email); }
            if (!string.IsNullOrEmpty(status)) { BPage.SelectStatus(status); }

            BPage.ClickBtnSearch();
        }

        public void ClearSearch() => BPage.ClickBtnClear();

        public bool IsTableResultDisplayed() => BPage.IsTableResultDisplayed();

        public bool IsDivNoResultsDisplayed() => BPage.IsDivNoResultsDisplayed();

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
                    values.ElementAt(4)
                );

                results.Add(cliente);
            }

            return results;
        }

        public void AccessToEdit(int index) => BPage.AccessToEdit(index);

        public void AccessToEditByID(int id)
        {
            List<Cliente> clientes = GetTableResults();

            int index = clientes.FindIndex(c => c.Id == id);

            BPage.AccessToEdit(index);
        }
    }
}
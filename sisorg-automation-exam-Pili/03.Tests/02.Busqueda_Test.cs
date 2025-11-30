using sisorg_automation_exam_MP.Functions;
using sisorg_automation_exam_MP.Functions.DTOs;

using System.Configuration;

namespace sisorg_automation_exam_MP.Tests
{
    [TestClass]
    public class Busqueda_Test : Base_Test
    {
        Busqueda_Functions BusquedaFunctions;

        public Busqueda_Test() : base() { BusquedaFunctions = new Busqueda_Functions(Driver); }

        private void FirstStep() { 
        
            new Login_Functions(Driver).Login();
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_Usuario_Logeado"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_Usuario_Logeado()
        {
            FirstStep();

            string usuarioEsperado = ConfigurationManager.AppSettings["Usuario"] ?? "admin";
      
            string usuarioActual = BusquedaFunctions.GetLoggedUserName();

            Assert.AreEqual(usuarioEsperado, usuarioActual, $"El usuario logeado no es el esperado. Actual: '{usuarioActual}'. Esperado: '{usuarioEsperado}'");
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_TituloPagina"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_TituloPagina()
        {
            FirstStep();

            bool result = BusquedaFunctions.ExistsBusquedaPage(out string title);

            Assert.IsTrue(result, "No se encontró la página de Búsqueda de Clientes.");
            Assert.AreEqual("Búsqueda de Clientes", title, $"El título de la página no es el esperado.");
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_PorNombre_Exacto"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_PorNombre_Exacto()
        {
            FirstStep();

            string criterio = "Roberto Sánchez";

            BusquedaFunctions.Search(name: criterio);

            List<Functions.DTOs.Cliente> resultados = BusquedaFunctions.GetTableResults();

            foreach (var cliente in resultados)
            {
                Assert.AreEqual(criterio, cliente.Nombre, $"El nombre del cliente (Id {cliente.Id}) no coincide con el criterio de búsqueda. Actual: '{cliente.Nombre}'. Esperado: '{criterio}'");
            }
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_PorNombre_NoExacto"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_PorNombre_NoExacto()
        {
            FirstStep();

            string criterio = "ma";

            BusquedaFunctions.Search(name: criterio);

            List<Functions.DTOs.Cliente> resultados = BusquedaFunctions.GetTableResults();

            foreach (var cliente in resultados)
            {
                Assert.Contains(criterio.ToLower(), cliente.Nombre.ToLower(), $"El nombre del cliente (Id {cliente.Id}) no contiene el criterio de búsqueda. Nombre: '{cliente.Nombre}'. Debe contener: '{criterio}'");
            }
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_PorEmail_Exacto"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_PorEmail_Exacto()
        {
            FirstStep();

            string criterio = "maria.garcia@empresa.com";

            BusquedaFunctions.Search(email: criterio);

            List<Functions.DTOs.Cliente> resultados = BusquedaFunctions.GetTableResults();

            foreach (var cliente in resultados)
            {
                Assert.AreEqual(criterio, cliente.Email, $"El email del cliente (Id {cliente.Id}) no coincide con el criterio de búsqueda. Actual: '{cliente.Email}'. Esperado: '{criterio}'");
            }
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_PorNombre_NoExacto"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_PorEmail_NoExacto()
        {
            FirstStep();

            string criterio = "ma";

            BusquedaFunctions.Search(email: criterio);

            List<Functions.DTOs.Cliente> resultados = BusquedaFunctions.GetTableResults();

            foreach (var cliente in resultados)
            {
                Assert.Contains(criterio.ToLower(), cliente.Email.ToLower(), $"El email del cliente (Id {cliente.Id}) no contiene el criterio de búsqueda. Email: '{cliente.Email}'. Debe contener: '{criterio}'");
            }
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_PorEstado_Activo"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_PorEstado_Activo()
        {
            FirstStep();

            string criterio = "Activo";

            BusquedaFunctions.Search(status: criterio);

            List<Functions.DTOs.Cliente> resultados = BusquedaFunctions.GetTableResults();

            foreach (var cliente in resultados)
            {
                Assert.AreEqual(criterio, cliente.Estado, $"El estado del cliente (Id {cliente.Id}) no coincide con el criterio de búsqueda. Actual: '{cliente.Estado}'. Esperado: '{criterio}'");
            }
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_PorEstado_Inactivo"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_PorEstado_Inactivo()
        {
            FirstStep();

            string criterio = "Inactivo";

            BusquedaFunctions.Search(status: criterio);

            List<Functions.DTOs.Cliente> resultados = BusquedaFunctions.GetTableResults();

            foreach (var cliente in resultados)
            {
                Assert.AreEqual(criterio, cliente.Estado, $"El estado del cliente (Id {cliente.Id}) no coincide con el criterio de búsqueda. Actual: '{cliente.Estado}'. Esperado: '{criterio}'");
            }
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_PorVarioCriterios"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_PorVarioCriterios()
        {
            FirstStep();

            string criterioNombre = "ma";
            string criterioEmail = ".garcia";
            string criterioEstado = "Activo";

            BusquedaFunctions.Search(criterioNombre, criterioEmail, criterioEstado);

            List<Functions.DTOs.Cliente> resultados = BusquedaFunctions.GetTableResults();

            foreach (var cliente in resultados)
            {
                Assert.Contains(criterioNombre.ToLower(), cliente.Nombre.ToLower(), $"El estado del cliente (Id {cliente.Id}) no coincide con el criterio de búsqueda. Actual: '{cliente.Nombre}'. Esperado: '{criterioNombre}'");
                Assert.Contains(criterioEmail.ToLower(), cliente.Email.ToLower(), $"El estado del cliente (Id {cliente.Id}) no coincide con el criterio de búsqueda. Actual: '{cliente.Email}'. Esperado: '{criterioEmail}'");
                Assert.AreEqual(criterioEstado, cliente.Estado, $"El estado del cliente (Id {cliente.Id}) no coincide con el criterio de búsqueda. Actual: '{cliente.Estado}'. Esperado: '{criterioEstado}'");
            }
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_ListaVacia"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_ListaVacia()
        {
            FirstStep();

            string criterioNombre = "García María";

            BusquedaFunctions.Search(criterioNombre);

            Assert.IsTrue(BusquedaFunctions.IsDivNoResultsDisplayed(), "No se muestra el mensaje 'No se encontraron registros...'");
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Busqueda_AccesoEditar"), TestProperty("TestExecutionCategory", "Busqueda")]
        public void Busqueda_AccesoEditar()
        {
            FirstStep();

            string criterio = "maria.garcia@empresa.com";

            BusquedaFunctions.Search(email: criterio);

            Cliente clienteEditar = BusquedaFunctions.GetTableResults().FirstOrDefault();

            BusquedaFunctions.AccessToEdit(0);

            Assert.Contains($"edit.html?id={clienteEditar.Id}", Driver.Url, $"Para el ID '{clienteEditar.Id}' No se ingreso a la pantalla de edición. URL: {Driver.Url}");
        }
    }
}

using sisorg_automation_exam_MP.Functions;
using sisorg_automation_exam_MP.Functions.DTOs;

using System.Configuration;

namespace sisorg_automation_exam_MP.Tests
{
    [TestClass]
    public class Edicion_Test : Base_Test
    {
        Edicion_Functions EdicionFunctions;

        public Edicion_Test() : base() { EdicionFunctions = new Edicion_Functions(Driver); }

        Cliente ClienteToEdit;

        private void FirstStep() {

            new Login_Functions(Driver).Login();
            Busqueda_Functions BF = new Busqueda_Functions(Driver);

            BF.Search(email: "roberto.sanchez@empresa.com");
            ClienteToEdit = BF.GetTableResults().FirstOrDefault();
            BF.AccessToEdit(0);
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Editar_TituloPagina"), TestProperty("TestExecutionCategory", "Editar")]
        public void Editar_TituloPagina()
        {
            FirstStep();

            bool result = EdicionFunctions.ExistsEdicionPage(out string title);

            Assert.IsTrue(result, "No se encontró la página de Edición de Cliente.");
            Assert.AreEqual("Edición de Cliente", title, $"El título de la página no es el esperado.");
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Editar_ValidarID"), TestProperty("TestExecutionCategory", "Editar")]
        public void Editar_ValidarID()
        {
            FirstStep();

            bool result = EdicionFunctions.GetClientID(out string clientId);

            Assert.IsFalse(result, "El campor 'ID Cliente' se muestra habilidato.");
            Assert.AreEqual(ClienteToEdit.Id.ToString(), clientId, $"La pantalla de edición no muestra el ID esperado. Actual '{clientId}'. Esperado {ClienteToEdit.Id}");
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Editar_CamposObligatorios"), TestProperty("TestExecutionCategory", "Editar")]
        public void Editar_CamposObligatorios()
        {
            FirstStep();

            bool result = EdicionFunctions.EditClient(out List<string> errors, "", "", "", "");

            Assert.IsFalse(result, "Al guardar sin completar campos se muestra el mensaje de éxito");
            
            List<string> expectedValidatios = new List<string>
            {
                "El campo Nombre es requerido.",
                "El campo Email es requerido.",
                "El campo Teléfono es requerido.",
                "El campo Estado es requerido."
            };

            foreach (string expectedValidation in expectedValidatios)
            {
                CollectionAssert.Contains(errors, expectedValidation, $"La lista de valiaciónes no muestra: '{expectedValidation}'");
            }
        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Editar_CampoEmailIncorrecto"), TestProperty("TestExecutionCategory", "Editar")]
        public void Editar_CampoEmailIncorrecto()
        {
            FirstStep();

            bool result = EdicionFunctions.EditClient(out List<string> errors, email:"matias");

            Assert.IsFalse(result, "Al guardar sin completar campos se muestra el mensaje de éxito");

            CollectionAssert.Contains(errors, "El formato del Email no es válido.", $"La lista de valiaciónes no muestra: 'El formato del Email no es válido.'");

        }

        [TestMethod]
        [TestProperty("TestExecutionName", "Editar_GuardadoExitoso"), TestProperty("TestExecutionCategory", "Editar")]
        public void Editar_GuardadoExitoso()
        {
            FirstStep();

            bool result = EdicionFunctions.EditClient(out List<string> messeges, email: "matiaspili@gmail.com");

            Assert.IsTrue(result, "Al guardar no se muestra el mensaje de éxito");

            CollectionAssert.Contains(messeges, $"Los datos del cliente se guardaron exitosamente. ID: {ClienteToEdit.Id}", $"El mensaje de éxito no muesta el texto esperado.");

        }
    }
}

using OpenQA.Selenium;

using sisorg_automation_exam_MP.Functions.DTOs;
using sisorg_automation_exam_MP.Pages.Login;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisorg_automation_exam_MP.Functions
{
    public class Edicion_Functions
    {
        public Edicion_Page EPage;

        public Edicion_Functions(IWebDriver driver) => EPage = new Edicion_Page(driver);

        public bool ExistsEdicionPage(out string title) => EPage.ExistsPage(out title);

        /// <summary>
        /// Se obtien el ID del cliente, retornando si el campo está habilitado (editable).
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public bool GetClientID(out string clientID)
        {
            bool result = EPage.IsClientIDEnable();
            clientID = EPage.GetClientID();
            return result;
        }

        public Cliente GetCliente()
        {
            return new Cliente
             (
                 EPage.GetClientID(),
                 EPage.GetName(),
                 EPage.GetEmail(),
                 EPage.GetPhone(),
                 EPage.GetStatus()
             );
        }

        /// <summary>
        /// Método para la edición de un cliente.
        /// - Si un parámetro es cadena vacía, se limpia el valor del campo.
        /// - Si un parámetro es un valor null, no se modifica el valor del campo.
        /// </summary>
        /// <param name="name">Nuevo nombre</param>
        /// <param name="email">Nuevo email</param>
        /// <param name="phone">Nuevo teléfono</param>
        /// <param name="status">Nuevo estado</param>
        /// <returns></returns>
        public bool EditClient(out List<string> messages, string? name = null, string? email = null, string? phone = null, string? status = null)
        {
            if (name != null) { EPage.SetName(name); }
            if (email != null) { EPage.SetEmail(email); }
            if (phone != null) { EPage.SetPhone(phone); }
            if (status != null) { if (status != "") { EPage.SelectStatus(status); } else { EPage.DeselectStatus(); } }

            EPage.ClickBtnSave();

            if (EPage.ExistsSuccessMessage(out string successMessage))
            {
                messages = new List<string> { successMessage };
                return true;
            }
            else
            {
                if (EPage.ExistsValidationErrors(out messages))
                {
                    return false;
                }
                else
                {
                    messages = new List<string> { "Luego de guardar no se mostró ni el mensaje de éxito ni la lista de errores." };
                    return false;
                }
            }
        }
    }
}

using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisorg_automation_exam_MP.Tools
{
    public static class UtilsExtendMethods
    {
        /// <summary>
        /// Devuelve el mensaje de la exepción, considerando, o no, la exepción interna.
        /// </summary>
        /// <param name="ex">Exception" de la que se desea obtener el mensaje</param>
        /// <param name="addInnerException">Determina si se desea incorporar el mensaje de la exepción interna</param>
        /// <param name="addTargetSite"><see langword="true"/> si se desea agrear el 'TargetSite' que originó la excepción</param>
        /// <returns>Mensaje de la exepción</returns>
        public static string MessageToString(this Exception ex, bool addInnerException, bool addTargetSite = false)
        {
            string msgInner = "";
            if (addInnerException && ex.InnerException != null)
            {
                string exInnerExceptionMessage = ex.InnerException.MessageToString(addInnerException);
                msgInner = string.IsNullOrEmpty(exInnerExceptionMessage) ? "" : "\n" + exInnerExceptionMessage;
            }

            string exTargetSite = addTargetSite ? $"En '{ex.TargetSite}'.\n" : "";

            return $"{exTargetSite}{ex.Message}{msgInner}";

        }

        /// <summary>
        /// Método de extensión para limpiar y cerrar una instancia de IWebDriver
        /// </summary>
        /// <param name="driver">Instancia del Driver</param>
        public static void ClearWebDriver(this IWebDriver driver)
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}

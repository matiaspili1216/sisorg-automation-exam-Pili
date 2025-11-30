using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using sisorg_automation_exam_MP.Tools;
using sisorg_automation_exam_MP.Tools.ChromeDriverCreate;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisorg_automation_exam_MP.Tests
{
    public class Base_Test
    {
        public ChromeDriver Driver;

        public TestContext TestContext { get; set; }

        private string _DownloadDirectory;
        public string DownloadDirectory
        {
            get { return _DownloadDirectory; }
            private set
            {
                _DownloadDirectory = value;

                if (!string.IsNullOrEmpty(_DownloadDirectory) && !Directory.Exists(_DownloadDirectory)) { Directory.CreateDirectory(_DownloadDirectory); }
            }
        }

        public Base_Test()
        {
            //bool isHeadless = true, TimeSpan? commandTimeout = null, ChromeOptions chromeOptions = null
            try
            {
                DownloadDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}Descargas";

                var options = new CreateDriverOptions
                {
                    IsHeadless = !System.Diagnostics.Debugger.IsAttached
                };
                options.ChromeOptions.AddUserProfilePreference("download.default_directory", DownloadDirectory);
                options.DownloadDefaultDirectory = DownloadDirectory;

                Driver = new WebDriverFactory().Create(options);

                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("ChromeDriver only supports"))
                {
                    throw new Exception("ChromeDriver incompatible con la versión de Chrome instalada.\n" + e.MessageToString(true));
                }
                else
                {
                    throw e;
                }
            }
        }

        #region AssemblyInitialize/Cleanup

        [AssemblyInitialize]
        public static void InitAssembly(TestContext test)
        {
            /*
             TO DO
                    Lógica asociada a la configuración del reporte de pruebas
             
             */
        }

        [AssemblyCleanup]
        public static void CleanAssebly()
        {
            /*
             TO DO
                    Lógica asociada al cierre del reporte de pruebas

            */
        }

        #endregion

        #region TestInitialize/Cleanup

        private string TestExecutionNameValue = "";

        [TestInitialize]
        public void TestInitialize()
        {
            IEnumerable<TestPropertyAttribute> properties = GetType().GetMethod(TestContext.TestName).GetCustomAttributes(true).OfType<TestPropertyAttribute>();
            TestPropertyAttribute TestExecutionName = properties.FirstOrDefault(Test => Test.Name == "TestExecutionName");
            TestExecutionNameValue = TestExecutionName == null ? TestContext.TestName : TestExecutionName.Value;

            TestPropertyAttribute TestExecutionCategory = properties.FirstOrDefault(Test => Test.Name == "TestExecutionCategory");
            string TestExecutionCategoryValue = TestExecutionCategory == null ? "Unknown" : TestExecutionCategory.Value;

            Console.WriteLine($"Se inicia el Test '{TestExecutionNameValue}'");

            /*
             TO DO
                    Lógica asociada a la configuración del reporte de pruebas, para el test actual.
             
             */

            Driver.Navigate().GoToUrl($"{Directory.GetCurrentDirectory()}/src/login.html");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            /*
             TO DO
                    Lógica asociada al cierre del reporte de pruebas, para el test actual.
             
             */

            Driver.ClearWebDriver();

            Console.WriteLine($"Finalizó el Test '{TestContext.FullyQualifiedTestClassName}'");
        }

        #endregion
    }
}

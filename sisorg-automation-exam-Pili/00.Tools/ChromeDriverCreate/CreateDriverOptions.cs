using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisorg_automation_exam_MP.Tools.ChromeDriverCreate
{
    public class CreateDriverOptions
    {
        public string DriverFolder { get; set; } = new ChromeDriverDownload.DriverDownload().DownloadDriverAndGetFolderPath();
        public string BrowserVersion { get; set; } = new ChromeDriverDownload.ChromeVersion().GetChromeFullVersion();
        public OpenQA.Selenium.Chrome.ChromeOptions ChromeOptions { get; set; } = new OpenQA.Selenium.Chrome.ChromeOptions();
        public TimeSpan? CommandTimeout { get; set; } = null;
        public TimeSpan ImplicitWait { get; set; } = TimeSpan.FromSeconds(1);
        public bool IsHeadless { get; set; } = true;
        public string DownloadDefaultDirectory { get; set; } = $"{AppDomain.CurrentDomain.BaseDirectory}\\Descargas";
    }
}

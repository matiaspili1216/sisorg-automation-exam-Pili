using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace sisorg_automation_exam_MP.Tools.ChromeDriverCreate
{
    public class WebDriverFactory
    {
        public ChromeDriver Create()
        {
            CreateDriverOptions createDriverOptions = new CreateDriverOptions();

            ChromeDriver _driver = createDriverOptions.CommandTimeout.HasValue ? new ChromeDriver(createDriverOptions.DriverFolder, createDriverOptions.ChromeOptions, createDriverOptions.CommandTimeout.Value) : new ChromeDriver(createDriverOptions.DriverFolder, createDriverOptions.ChromeOptions);

            return _driver;
        }

        public ChromeDriver Create(CreateDriverOptions createDriverOptions)
        {
            if (createDriverOptions.IsHeadless)
            {
                createDriverOptions.ChromeOptions.AddArgument("-window-size=1366x768");
                createDriverOptions.ChromeOptions.AddArgument("headless");
                createDriverOptions.ChromeOptions.AddArgument("no-sandbox");
            }
            else
            {
                createDriverOptions.ChromeOptions.AddArgument(" --start-maximized");
                createDriverOptions.ChromeOptions.AddArgument("no-sandbox");
            }

            ChromeDriver _driver = createDriverOptions.CommandTimeout.HasValue ? new ChromeDriver(createDriverOptions.DriverFolder, createDriverOptions.ChromeOptions, createDriverOptions.CommandTimeout.Value) : new ChromeDriver(createDriverOptions.DriverFolder, createDriverOptions.ChromeOptions);

            return _driver;
        }
    }
}

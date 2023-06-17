using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NvidiaUpdate
{
    public partial class FormMain : Form
    {
        private static readonly string repositoryPath = @"D:\Downloads";
        private List<string> log = new();
        private Query query = new();

        private ChromeDriverService? service;
        private IWebDriver? driver;
        private WebDriverWait wait;

        public FormMain()
        {
            InitializeComponent();
            InitializeWebDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
        }

        #region Events
        private void FormMain_Load(object sender, EventArgs e)
        {
            string versionNumber = Manager.GetLatestDriverVersion();

            log.Add($"Current version: {Manager.GetCurrentDriverVersion()}\n");
            log.Add($"Latest version: {versionNumber}\n");

            log.Add("\n");

            log.Add($"Product type: {query.ProductType}\n");
            log.Add($"Product series: {query.ProductSeries}\n");
            log.Add($"Product: {query.Product}\n");
            log.Add($"Operating System: {query.OperatingSystem}\n");
            log.Add($"Download type: {query.DownloadType}\n");
            log.Add($"Language: {query.Language}\n");

            log.Add("\n");

            listBox1.Items.AddRange(log.ToArray());
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            driver?.Quit();
            driver?.Dispose();
            service?.Dispose();

            string[] crdownloadFiles = Directory.GetFiles(repositoryPath, "*.crdownload");
            foreach (string crdownloadFile in crdownloadFiles)
            {
                File.Delete(crdownloadFile);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RunWebDriver();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", repositoryPath);
        }
        #endregion

        #region Driver Code
        private void RunWebDriver()
        {
            if (driver != null)
            {
                driver.Navigate().GoToUrl("https://www.nvidia.com/Download/index.aspx?lang=en-us");

                SelectComboBox(driver, "selProductSeriesType", $"{query.ProductType}");
                SelectComboBox(driver, "selProductSeries", $"{query.ProductSeries}");
                SelectComboBox(driver, "selProductFamily", $"{query.Product}");
                SelectComboBox(driver, "selOperatingSystem", $"{query.OperatingSystem}");
                SelectComboBox(driver, "ddlDownloadTypeCrdGrd", $"{query.DownloadType}");
                SelectComboBox(driver, "ddlLanguage", $"{query.Language}");

                listBox1.Items.Add("\n");

                IWebElement searchButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("btn_drvr_lnk_txt")));
                searchButton.Click();
                IWebElement downloadButton1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("btn_drvr_lnk_txt")));
                downloadButton1.Click();
                IWebElement downloadButton2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("btn_drvr_lnk_txt")));
                downloadButton2.Click();

                listBox1.Items.Add("Download is started!\n");
            }
        }
        private void SelectComboBox(IWebDriver driver, string comboBoxName, string optionText)
        {
            IWebElement comboBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(comboBoxName)));
            SelectElement selectElement = new SelectElement(comboBox);

            selectElement.SelectByText(optionText);

            listBox1.Items.Add($"{optionText} is set!");
        }
        private void InitializeWebDriver()
        {
            service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddUserProfilePreference("download.default_directory", repositoryPath);

            driver = new ChromeDriver(service, options);
        }
        #endregion
    }
}

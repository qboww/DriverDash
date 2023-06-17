using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace NvidiaUpdate
{
    public partial class FormMain : Form
    {
        private ChromeDriverService service;
        private IWebDriver driver;
        
        public static string? repositoryPath = @"D:\Downloads";
        List<string> log = new List<string>();
        Query query = new();

        public FormMain()
        {
            InitializeComponent();
        }

        #region Events
        private void FormMain_Load(object sender, EventArgs e)
        {
            string text = string.Empty;
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

        private void button1_Click(object sender, EventArgs e)
        {
            RunWebDriver();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", repositoryPath);
        }
        #endregion

        public void RunWebDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddUserProfilePreference("download.default_directory", "D:\\Downloads");

            driver = new ChromeDriver(service, options);
            this.TopMost = true;
            driver.Navigate().GoToUrl("https://www.nvidia.com/Download/index.aspx?lang=en-us");

            SelectComboBox(driver, "selProductSeriesType", $"{query.ProductType}");
            SelectComboBox(driver, "selProductSeries", $"{query.ProductSeries}");
            SelectComboBox(driver, "selProductFamily", $"{query.Product}");
            SelectComboBox(driver, "selOperatingSystem", $"{query.OperatingSystem}");
            SelectComboBox(driver, "ddlDownloadTypeCrdGrd", $"{query.DownloadType}");
            SelectComboBox(driver, "ddlLanguage", $"{query.Language}");

            IWebElement searchButton = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
            searchButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btn_drvr_lnk_txt")));

            IWebElement downloadButton1 = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
            downloadButton1.Click();

            Thread.Sleep(1000);

            IWebElement downloadButton2 = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
            downloadButton2.Click();
            listBox1.Items.Add("Download is started!\n");
        }

        private void SelectComboBox(IWebDriver driver, string comboBoxName, string optionText)
        {
            IWebElement comboBox = driver.FindElement(By.Name(comboBoxName));

            SelectElement selectElement = new SelectElement(comboBox);
            IList<IWebElement> options = selectElement.Options;

            foreach (IWebElement option in options)
            {
                if (option.Text.Contains(optionText))
                {
                    option.Click();
                    break;
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
            if (service != null)
            {
                service.Dispose();
            }

            string downloadDirectory = "D:\\Downloads";
            string[] crdownloadFiles = Directory.GetFiles(downloadDirectory, "*.crdownload");
            foreach (string crdownloadFile in crdownloadFiles)
            {
                File.Delete(crdownloadFile);
            }
        }

        public void SelectComboBoxItemByKeyword(string comboBoxId, string keyword)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.nvidia.com/download/index.aspx?lang=en-us");

            HtmlNode selectNode = doc.DocumentNode.SelectSingleNode($"//select[@id='{comboBoxId}']");
            if (selectNode == null)
            {
                return;
            }

            HtmlNode option = selectNode.Descendants("option").FirstOrDefault(opt => opt.InnerText.Contains(keyword));
            if (option == null)
            {
                return;
            }

            option.SetAttributeValue("selected", "selected");
            log.Add($"{keyword} - Done!\n");
        }
    }
}

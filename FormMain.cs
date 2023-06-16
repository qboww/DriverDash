using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NvidiaUpdate
{
    public partial class FormMain : Form
    {
        private IWebDriver driver;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Query query = new Query();

            label1.Text = $"Product type: {query.ProductType}";
            label2.Text = $"Product series: {query.ProductSeries}";
            label3.Text = $"Product: {query.Product}";
            label4.Text = $"Operating System: {query.OperatingSystem}";
            label5.Text = $"Download type: {query.DownloadType}";
            label6.Text = $"Language: {query.Language}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Query query = new Query();

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddUserProfilePreference("download.default_directory", "D:\\Downloads");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            driver = new ChromeDriver(service, options);

            driver.Navigate().GoToUrl("https://www.nvidia.com/Download/index.aspx?lang=en-us");

            SelectComboBox(driver, "selProductSeriesType", $"{query.ProductType}");
            SelectComboBox(driver, "selProductSeries", $"{query.ProductSeries}");
            SelectComboBox(driver, "selProductFamily", $"{query.Product}");
            SelectComboBox(driver, "selOperatingSystem", $"{query.OperatingSystem}");
            SelectComboBox(driver, "ddlDownloadTypeCrdGrd", $"{query.DownloadType}");
            SelectComboBox(driver, "ddlLanguage", $"{query.Language}");

            IWebElement searchButton = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
            searchButton.Click();

            IWebElement downloadButton1 = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
            downloadButton1.Click();

            IWebElement downloadButton2 = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
            downloadButton2.Click();
        }

        private void SelectComboBox(IWebDriver driver, string comboBoxName, string optionText)
        {
            IWebElement comboBox = driver.FindElement(By.Name(comboBoxName));

            SelectElement selectElement = new SelectElement(comboBox);
            selectElement.SelectByText(optionText);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Quit the driver and dispose it
            driver.Quit();
            driver.Dispose();

            // Delete the file with ".crdownload" extension
            string downloadDirectory = "D:\\Downloads";
            string[] crdownloadFiles = Directory.GetFiles(downloadDirectory, "*.crdownload");
            foreach (string crdownloadFile in crdownloadFiles)
            {
                File.Delete(crdownloadFile);
            }
        }

    }
}

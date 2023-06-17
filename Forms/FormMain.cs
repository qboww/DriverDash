using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.Json;

namespace DriverDash
{
    public partial class FormMain : Form
    {
        private string updateSize = Manager.GetDriverSize().ToString().Replace(".", ",");
        public static string filePath = @"..\..\..\path.json";
        private Query query = new();

        private short mov;
        private short movX;
        private short movY;

        private ChromeDriverService? service;
        private IWebDriver? driver;

        private string downloadPath;

        public FormMain()
        {
            InitializeComponent();
            LoadDownloadPath();
        }

        #region Events
        private void FormMain_Load(object sender, EventArgs e)
        {
            string driverCurrentVersion = Manager.GetCurrentDriverVersion();
            string driverLatestVersion = Manager.GetLatestDriverVersion();

            labelCurrentVersionData.Text = driverCurrentVersion + " WHQL";
            labelLatestVersionData.Text = driverLatestVersion + " WHQL";

            if (driverCurrentVersion != driverLatestVersion)
            {
                labelCurrentVersionData.ForeColor = Color.Red;
                labelLatestVersionData.ForeColor = Color.LimeGreen;
            }
            else
            {
                labelCurrentVersionData.ForeColor = Color.FromKnownColor(KnownColor.Control);
                labelLatestVersionData.ForeColor = Color.FromKnownColor(KnownColor.Control);
            }

            labelTypeData.Text = query.ProductType;
            labelSeriesData.Text = query.ProductSeries;
            labelProductData.Text = query.Product;
            labelOSData.Text = query.OperatingSystem;
            labelLoadTypeData.Text = query.DownloadType;
            labelLanguageData.Text = query.Language;
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            driver?.Quit();
            driver?.Dispose();
            service?.Dispose();

            if (downloadPath != null)
            {
                string[] crdownloadFiles = Directory.GetFiles(downloadPath, "*.crdownload");
                foreach (string crdownloadFile in crdownloadFiles)
                {
                    File.Delete(crdownloadFile);
                }
            }
        }
        private void buttonDownload_Click(object sender, EventArgs e)
        {
            labelStateData.ForeColor = Color.FromKnownColor(KnownColor.Control);
            labelStateData.Text = "Initializing";
            labelStateData.ForeColor = Color.LightPink;

            InitializeWebDriver();
            RunWebDriver();

            labelTotalData.Text = $"{updateSize}";

            timer1.Start();
        }
        private void buttonCheckFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", downloadPath);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string crdownloadFilePath = GetCrdownloadFilePath();

            if (!string.IsNullOrEmpty(crdownloadFilePath))
            {
                long currentFileSize = new FileInfo(crdownloadFilePath).Length;

                labelLoadedData.Text = $"{FormatFileSize(currentFileSize)}";

                if (updateSize == FormatFileSize(currentFileSize))
                {
                    timer1.Stop();

                    labelStateData.ForeColor = Color.FromKnownColor(KnownColor.Control);
                    labelStateData.Text = "Downloaded";
                    labelStateData.ForeColor = Color.LimeGreen;
                }
            }
        }
        private void panelTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = (short)e.X;
            movY = (short)e.Y;
        }
        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonSetPath_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    downloadPath = folderDialog.SelectedPath;
                    SaveDownloadPath();
                }
            }
        }
        #endregion

        #region OtherFuncs
        private string GetCrdownloadFilePath()
        {
            string[] crdownloadFiles = Directory.GetFiles(downloadPath, "*.crdownload");
            if (crdownloadFiles.Length > 0)
            {
                return crdownloadFiles.First();
            }
            return string.Empty;
        }
        private string FormatFileSize(long sizeInBytes)
        {
            const decimal megabyte = 1024 * 1024;
            decimal adjustedSize = (decimal)sizeInBytes / megabyte;
            return $"{adjustedSize:n1} MB";
        }
        private void SaveDownloadPath()
        {
            try
            {
                var downloadPathJson = JsonSerializer.Serialize(downloadPath);
                File.WriteAllText(filePath, downloadPathJson);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving download path: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDownloadPath()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var downloadPathJson = File.ReadAllText(filePath);
                    downloadPath = JsonSerializer.Deserialize<string>(downloadPathJson);
                }
            }
            catch (Exception ex)
            {
                labelStateData.ForeColor = Color.FromKnownColor(KnownColor.Control);
                labelStateData.Text = "Path not set";
                labelStateData.ForeColor = Color.Red;
            }
        }
        #endregion

        #region WebDriver
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

                IWebElement searchButton = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
                searchButton.Click();
                IWebElement downloadButton1 = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
                downloadButton1.Click();
                IWebElement downloadButton2 = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
                downloadButton2.Click();

                labelStateData.ForeColor = Color.FromKnownColor(KnownColor.Control);
                labelStateData.Text = "Downloading";
                labelStateData.ForeColor = Color.Cyan;
            }
        }
        private void SelectComboBox(IWebDriver driver, string comboBoxName, string optionText)
        {
            IWebElement comboBox = driver.FindElement(By.Id(comboBoxName));
            SelectElement selectElement = new SelectElement(comboBox);

            selectElement.SelectByText(optionText);
        }
        private void InitializeWebDriver()
        {
            service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddUserProfilePreference("download.default_directory", downloadPath);

            driver = new ChromeDriver(service, options);
        }
        #endregion
    }
}

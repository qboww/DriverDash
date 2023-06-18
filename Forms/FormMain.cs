using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Text.Json;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace DriverDash
{
    public partial class FormMain : Form
    {
        private string updateSize = GetDriverSize().ToString().Replace(".", ",");
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

                    Thread.Sleep(2000);
                    OpenDownloadedFile(crdownloadFilePath);
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
        private void OpenDownloadedFile(string filePath)
        {
            try
            {
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string GetDriverSize()
        {
            string url = "https://www.techpowerup.com/download/nvidia-geforce-graphics-drivers/";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);

            HtmlNode fileSizeNode = document.DocumentNode.SelectSingleNode("//div[@class='filesize']");
            string fileSizeText = fileSizeNode.InnerText.Trim();

            return fileSizeText;
        }
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
                driver.Navigate().GoToUrl("https://www.techpowerup.com/download/nvidia-geforce-graphics-drivers/");

                ReadOnlyCollection<IWebElement> downloadButtons = driver.FindElements(By.CssSelector("input.button.startbutton[value='Download']"));

                if (downloadButtons.Count > 0)
                {
                    downloadButtons[0].Click();

                    IWebElement serverButton = driver.FindElement(By.XPath("//button[@type='submit' and @name='server_id' and @value='5']"));
                    serverButton.Click();

                    labelStateData.ForeColor = Color.FromKnownColor(KnownColor.Control);
                    labelStateData.Text = "Downloading";
                    labelStateData.ForeColor = Color.Cyan;
                }
            }
        }
        private void InitializeWebDriver()
        {
            service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument($"--window-position=-32000,-32000");
            options.AddUserProfilePreference("download.default_directory", downloadPath);

            driver = new ChromeDriver(service, options);
        }
        #endregion
    }
}
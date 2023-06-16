using Microsoft.Win32;
using NvAPIWrapper;
using NvAPIWrapper.GPU;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace NvidiaUpdate
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Query query = new();

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

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.nvidia.com/Download/index.aspx?lang=en-us");

            SelectComboBox(driver, "selProductSeriesType", $"{query.ProductType}");
            SelectComboBox(driver, "selProductSeries", $"{query.ProductSeries}");
            SelectComboBox(driver, "selProductFamily", $"{query.Product}");
            SelectComboBox(driver, "selOperatingSystem", $"{query.OperatingSystem}");
            SelectComboBox(driver, "ddlDownloadTypeCrdGrd", $"{query.DownloadType}");
            SelectComboBox(driver, "ddlLanguage", $"{query.Language}");

            IWebElement searchButton = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
            searchButton.Click();

            IWebElement download1Button = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
            download1Button.Click();

            IWebElement download2Button = driver.FindElement(By.ClassName("btn_drvr_lnk_txt"));
            download2Button.Click();
        }

        static void SelectComboBox(IWebDriver driver, string comboBoxName, string optionText)
        {
            IWebElement comboBox = driver.FindElement(By.Name(comboBoxName));

            SelectElement selectElement = new SelectElement(comboBox);
            selectElement.SelectByText(optionText);
        }
    }
}

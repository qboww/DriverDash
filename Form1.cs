using System.Diagnostics;
using System.Management;

namespace NvidiaUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = GetDiscreteGraphicsCardModel();
            label2.Text = GetNvidiaDriverVersion();
        }

        private string GetDiscreteGraphicsCardModel()
        {
            try
            {
                using (ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher("SELECT * FROM Win32_VideoController WHERE AdapterCompatibility LIKE '%NVIDIA%'"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string model = obj["Name"].ToString();
                        return $"GPU model: {model}";
                    }
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Management Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;
        }

        private string GetNvidiaDriverVersion()
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("nvidia-smi")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = processStartInfo })
                {
                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    string driverVersion = "Unknown";

                    int versionIndex = output.IndexOf("Driver Version:", StringComparison.OrdinalIgnoreCase);
                    if (versionIndex >= 0)
                    {
                        int endIndex = output.IndexOf(Environment.NewLine, versionIndex);
                        if (endIndex >= 0)
                        {
                            driverVersion = output.Substring(versionIndex + 16, endIndex - versionIndex - 16).Trim();

                            int cudaIndex = driverVersion.IndexOf("CUDA", StringComparison.OrdinalIgnoreCase);
                            if (cudaIndex >= 0)
                            {
                                driverVersion = driverVersion.Substring(0, cudaIndex).Trim();
                            }
                        }
                    }

                    process.WaitForExit();
                    return $"Driver Version: {driverVersion}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving NVIDIA driver version: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Unknown";
            }
        }
    }
}

using Microsoft.Win32;
using NvAPIWrapper;
using NvAPIWrapper.GPU;
using System.Text.RegularExpressions;

namespace NvidiaUpdate
{
    public static class Manager
    {
        public static string downloadType = "Game Ready Driver (GRD)";
        public static string language = "English (US)";

        public static void SystemMonitoring(Query query)
        {
            query.ProductType = GetProductType();
            query.ProductSeries = GetProductSeries();
            query.Product = GetProduct();
            query.OperatingSystem = GetOperatingSystem();
            query.DownloadType = downloadType;
            query.Language = language;
        }

        public static string GetProductType()
        {
            foreach (var gpu in PhysicalGPU.GetPhysicalGPUs())
            {
                if (gpu.GPUType == NvAPIWrapper.Native.GPU.GPUType.Discrete)
                {
                    string fullName = gpu.FullName.ToString();
                    string[] words = fullName.Split(' ');

                    foreach (string word in words)
                    {
                        if (word.StartsWith("GeForce", StringComparison.OrdinalIgnoreCase))
                        {
                            return word;
                        }
                    }
                }
            }

            return "Unknown";
        }

        public static string GetProductSeries()
        {
            foreach (var gpu in PhysicalGPU.GetPhysicalGPUs())
            {
                if (gpu != null)
                {
                    string tempName = GetProduct();

                    tempName = Regex.Replace(tempName, @"\d+", string.Empty).Trim();

                    var match = Regex.Match(GetProduct(), @"\d+");

                    if (match.Success)
                    {
                        int number = int.Parse(match.Value);
                        int divisionResult = number / 100;

                        if (divisionResult > 0)
                        {
                            tempName += $" {divisionResult} Series";
                        }
                    }

                    if (gpu.SystemType == NvAPIWrapper.Native.GPU.SystemType.Laptop)
                    {
                        if (!tempName.EndsWith("(Notebooks)"))
                        {
                            tempName += " (Notebooks)";
                        }
                    }

                    return tempName;
                }
            }
            return "Unknown";
        }

        public static string GetOperatingSystem()
        {
            string version = GetWindowsVersion();
            string architecture = GetWindowsArchitecture();

            return version + " " + architecture;
        }

        public static string GetCurrentDriverVersion()
        {
            NVIDIA.Initialize();

            string driverVersion = NVIDIA.DriverVersion.ToString();
            string formattedVersion = driverVersion.Insert(3, ".");

            return formattedVersion;
        }

        public static string GetProduct()
        {
            foreach (var gpu in PhysicalGPU.GetPhysicalGPUs())
            {
                if (gpu.GPUType == NvAPIWrapper.Native.GPU.GPUType.Discrete)
                {
                    string fullName = gpu.FullName.ToString();
                    fullName = fullName.Replace("NVIDIA ", "");

                    return fullName;
                }
            }

            return "Unknown";
        }

        public static string GetWindowsVersion()
        {
            string key = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key))
            {
                if (registryKey != null)
                {
                    string productName = registryKey.GetValue("ProductName") as string;
                    if (!string.IsNullOrEmpty(productName))
                    {
                        return RemoveModificationWords(productName.Trim());
                    }
                }
            }

            return "Unknown";
        }

        public static string GetWindowsArchitecture()
        {
            string environmentVariable = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return environmentVariable.Contains("64") ? "64-bit" : "32-bit";
        }

        public static string RemoveModificationWords(string productName)
        {
            string[] modificationWords = { "Home", "Pro", "Enterprise", "Education" };
            foreach (string word in modificationWords)
            {
                productName = productName.Replace(word, "").Trim();
            }

            return productName;
        }
    }
}

namespace NvidiaUpdate
{
    public class Query
    {
        public string ProductType = string.Empty;
        public string ProductSeries = string.Empty;
        public string Product = string.Empty;
        public string OperatingSystem = string.Empty;
        public string DownloadType = string.Empty;
        public string Language = string.Empty;

        public Query()
        {
            Manager.SystemMonitoring(this);
        }
    }
}

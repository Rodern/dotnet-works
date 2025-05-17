namespace BridgeMall.Models.Configuration
{
    public class HostUrls
    {
        public HostUrls()
        {

        }
        public HostUrls(HostUrls hostUrls)
        {
            Current = hostUrls.Current;
            CurrentBase = hostUrls.CurrentBase;
            Local = hostUrls.Local;
            SelfHost = hostUrls.SelfHost;
            LocalSecured = hostUrls.LocalSecured;
            LocalSecuredBase = hostUrls.LocalSecuredBase;
            HostBase = hostUrls.HostBase;
            Host = hostUrls.Host;
            NgRokTmpHostBase = hostUrls.NgRokTmpHostBase;
            NgRokTmpHost = hostUrls.NgRokTmpHost;
        }
        public string Current { get; set; } = string.Empty;
        public string CurrentBase { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public string SelfHost { get; set; } = string.Empty;
        public string LocalSecured { get; set; } = string.Empty;
        public string LocalSecuredBase { get; set; } = string.Empty;
        public string HostBase { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public string NgRokTmpHostBase { get; set; } = string.Empty;
        public string NgRokTmpHost { get; set; } = string.Empty;
    }
}

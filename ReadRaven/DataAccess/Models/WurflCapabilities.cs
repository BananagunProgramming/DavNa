namespace DataAccess.Models
{
    public class WurflCapabilities
    {
        public bool IsMobile { get; set; }
        public bool IsTablet { get; set; }
        public bool IsFullDesktop { get; set; }
        public bool IsTouchscreen { get; set; }
        public bool IsIOS { get; set; }
        public bool IsAndroid { get; set; }
        public string MobileBrowser { get; set; }
        public string MobileBrowserVersion { get; set; }
        public int? ResolutionWidth { get; set; }
        public int? ResolutionHeight { get; set; }
    }
}

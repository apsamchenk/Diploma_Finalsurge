using System;

namespace Core.Configuration
{
    public class BrowserConfiguration : IConfiguration
    {
        public string SectionName => "Browser";
        public bool Headless { get; set; }
        public string? Type { get; set; }
        public int ImplicityWait { get; set; }
        public string? FinalSurgeUserLogin { get; set; }
        public string? FinalSurgeUserPassword { get; set; }
    }
}

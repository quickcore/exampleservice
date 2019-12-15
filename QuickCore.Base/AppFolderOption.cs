using System;

namespace QuickCore
{
    [OptionsClass("AppFolder")]
    public class AppFolderOption
    {
        public string DataFolder { get; set; } = "app_data";

        public string LogFolder { get; set; } = "app_log";

        public string TempFolder { get; set; } = "app_temp";
    }
}

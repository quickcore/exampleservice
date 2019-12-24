using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore
{
    [OptionsClass("App")]
    public class AppOptions
    {
        public string DataFolder { get; set; } = "app_data";

        public string LogFolder { get; set; } = "app_log";

        public string TempFolder { get; set; } = "app_temp";

        public string[] Plugins { get; set; } = new[] { "*.dll" };

    }

    [OptionsClass("App")]
    public class WebAppOptions : AppOptions
    {
        public string[] MvcParts { get; set; } = new[] { "*.Api" };
    }
}

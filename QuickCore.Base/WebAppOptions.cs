using System;

namespace QuickCore
{
    [OptionsClass("App")]
    public class WebAppOptions : AppOptions
    {
        public string[] MvcParts { get; set; } = new[] { "*.Api" };
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore
{
    [OptionsClass]
    public class AppOptions
    {
        public string[] Plugins { get; set; } = new[] { "*.dll" };

        public string[] MvcParts { get; set; } = new[] { "*.Api" };
    }
}

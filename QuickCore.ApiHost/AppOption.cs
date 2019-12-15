using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCore.ApiHost
{
    [OptionsClass("App")]
    public class AppOption
    {
        public string[] Plugins { get; set; } = new[] { "*.dll" };

        public string[] MvcParts { get; set; } = new[] { "*.Api" };
    }
}

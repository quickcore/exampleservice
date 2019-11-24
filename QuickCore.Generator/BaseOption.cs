using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore.Generator
{
    public class BaseOption
    {
        [Option('d', "debug", Required = false, Default =false, HelpText = "Enable debug mode.")]
        public bool Debug { get; set; } = false;
    }
}

using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore.MicroService.Commands
{
    [Verb("create", HelpText = "Create a new micro service.")]
    public  class CreateOption
    {
        [Value(0, HelpText = "working directory.")]
        public string WorkingDirectory { get; set; }

        [Option('f', "file", Required = false, Default = "", HelpText = "app define file path")]
        public string AppfilePath { get; set; }
    }
}

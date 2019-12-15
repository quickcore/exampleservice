using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore.MicroService.Commands
{
    [Verb("deploy", HelpText = "deploy a micro service.")]
    public class DeployOption : ICommand<DeployOption>
    {
        public DeployOption Option { get; set; }

        public int Run()
        {
            return 0;
        }
    }
}

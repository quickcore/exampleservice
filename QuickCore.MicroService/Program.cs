using CommandLine;
using QuickCore.MicroService.Commands;
using System;

namespace QuickCore.MicroService
{
    class Program
    {
        static int Main(string[] args)
        {
            var settings = new Settings
            { 
              DockerPrefix="triday"
            };

            return Parser.Default.ParseArguments<CreateOption,DeployOption>(args)
                       .MapResult(
                         (CreateOption createOption) => new CreateCommand(settings, createOption).Run(),
                         (DeployOption deployOption) => new DeployCommand(deployOption).Run(),
                         errs => 1);
        }
    }
}

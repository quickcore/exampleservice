using CommandLine;
using QuickCore.Generator.Dockerfile;

namespace QuickCore.Generator
{
    class Program
    {
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<DockerfileOption>(args)
                 .MapResult(
                   (dockerOption) => new DockerfileCommand().Run(dockerOption),
                   errs => 1);
        }
    }
}

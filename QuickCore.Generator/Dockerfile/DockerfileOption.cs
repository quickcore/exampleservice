using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore.Generator.Dockerfile
{
    [Verb("docker", HelpText = "Generate a docker file for a c# web app project.")]
    public class DockerfileOption:BaseOption
    {
        [Option('p', "projectpath", Required = true, HelpText = "The c# project path.")]
        public string ProjectPath { get; set; }
        [Option('m', "mode", Required = false, Default = "Release", HelpText = "The build mode (eg. Debug,Release).")]
        public string BuildMode { get; set; }

        [Option('f', "force", Required = false, Default = false, HelpText = "Force to write the dockerfile, if true the current dockerfile will be covered.")]
        public bool Force { get; set; }
    }
}

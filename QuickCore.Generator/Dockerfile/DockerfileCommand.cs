using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace QuickCore.Generator.Dockerfile
{
    public class DockerfileCommand
    {
        public int Run(DockerfileOption option)
        {
            try
            {
                var context = this.BuildContext(option);
                new DockerfileGenerator().Generator(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(option.Debug ? ex.ToString() : ex.Message);
                return 1;
            }
            return 0;
        }

        public DockerfileContext BuildContext(DockerfileOption option)
        {

            if (!File.Exists(option.ProjectPath))
            {
                throw new ArgumentException($"The file '{option.ProjectPath}' don't exits.");
            }
            string fullProjectPath = Path.GetFullPath(option.ProjectPath);
            string fullCsprojDir = Path.GetDirectoryName(fullProjectPath);
            string slnDir = FindSolutionDir(fullCsprojDir);
            string csprojDir = Path.GetRelativePath(slnDir, fullCsprojDir);
            string csprojName = Path.GetFileName(option.ProjectPath);
            string targetDockerfile = Path.Combine(fullCsprojDir, "Dockerfile");

            var csprojDocument = System.Xml.Linq.XDocument.Load(fullProjectPath);
            var root = csprojDocument.Root;
            var netVersionElement = root.Element("PropertyGroup").Element("TargetFramework");
            var assemblyNameElement = root.Element("PropertyGroup").Element("AssemblyName");
            string entryDllName = assemblyNameElement == null ?
                                Path.GetFileNameWithoutExtension(csprojName) + ".dll" :
                                assemblyNameElement.Value + ".dll";
            return new DockerfileContext
            {
                BuildMode = option.BuildMode,
                CsprojDir = csprojDir,
                CsprojName = csprojName,
                Force = option.Force,
                RootDir = slnDir,
                TargetDockerfile = targetDockerfile,
                EntryDllName = entryDllName,
                NetCoreVersion = ExtractNetCoreVersion(netVersionElement.Value)

            };
        }
        private string FindSolutionDir(string csprojDir)
        {
            var dir = csprojDir;
            while (!HasSlnFile(dir))
            {
                if (Directory.GetDirectoryRoot(dir) == dir)
                {
                    throw new Exception("Can not find the sln file in parent directories.");
                }
                dir = Path.GetDirectoryName(dir);
            }
            return dir;

        }
        private bool HasSlnFile(string path)
        {
            return Directory.GetFiles(path, "*.sln", SearchOption.TopDirectoryOnly).Length > 0;
        }

        private string ExtractNetCoreVersion(string targetFramework)
        {
            if (targetFramework.StartsWith("netcoreapp"))
            {
                return targetFramework.Substring(10);
            }
            else
            {
                throw new Exception("The project is not a netcore app.");
            }
        }




    }
}

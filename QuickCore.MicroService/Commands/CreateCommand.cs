using QuickCore.MicroService.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace QuickCore.MicroService.Commands
{
    public class CreateCommand : ICommand<CreateOption>
    {
        public CreateCommand(Settings settings, CreateOption option)
        {
            this.Settings = settings;
            this.Option = option;
        }
        public Settings Settings { get; private set; }
        public CreateOption Option { get; private set; }
        public int Run()
        {
            var imageTag=BuildDocker();
            PushDocker(imageTag);
            return 0;
        }
        public string BuildDocker()
        {
            string workingDir =Path.GetFullPath(this.Option.WorkingDirectory);
            string appfile = string.IsNullOrEmpty(this.Option.AppfilePath) ? Path.Combine(workingDir, "app_define.json") : this.Option.AppfilePath;
            AppDefine appDefine = Json.ReadFromFile<AppDefine>(appfile);
            string dockerfile = Path.Combine(Path.GetDirectoryName(appfile), "Dockerfile");

            string imageTag = $"{this.Settings.DockerPrefix}/{appDefine.Name}:{appDefine.Version}";
             Shell.Exec("docker", $"build -f {dockerfile} -t {imageTag} {workingDir}");
            return imageTag;
        }
        public void PushDocker(string imageTag)
        {
            var res = Shell.Exec("docker", "login -u xxxx -p xxxx");
            var rr = Shell.Exec("docker", $"push {imageTag}");
            var res2 = Shell.Exec("docker", "logout");
         
        }

        public string CreateService()
        {
            return "";
        }
    }
}

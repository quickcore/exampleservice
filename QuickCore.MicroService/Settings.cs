using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore.MicroService
{
    public class Settings
    {
        public string ServiceCenterUrl { get; set; }

        public string DockerRepoUrl { get; set; }

        public string DockerRepoUser { get; set; }

        public string DockerRepoPassword { get; set; }

        public string DockerPrefix { get; set; }
    }
}

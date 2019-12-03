using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCenter.Core
{
    public class ServiceInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public List<DependOnItem> DependsOn { get; set; }
        public List<EnvItem> Envs { get; set; }


    }

    public class DependOnItem
    {
        public string Name { get; set; }
        public string VersionDesc { get; set; }
    }
    public class EnvItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore.Generator.Dockerfile
{
    public class DockerfileContext
    {
        public string RootDir { get; set; }
        public string CsprojDir { get; set; }

        public string CsprojName { get; set; }

        public string BuildMode { get; set; } = "Debug";

        public string EntryDllName { get; set; }

        public string NetCoreVersion { get; set; } = "3.0";

        public short? HttpPort { get; set; } = 80;
        public short? HttpsPort { get; set; } = 443;

        public string TargetDockerfile { get; set; }

        public bool Force { get; set; } = false;
    }
}

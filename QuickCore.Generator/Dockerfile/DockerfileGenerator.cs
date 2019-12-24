using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuickCore.Generator.Dockerfile
{
    public  class DockerfileGenerator
    {


        public void Generator(DockerfileContext context)
        {
            string content = CreateDockerFileContent(context);
            var fileMode = context.Force ? FileMode.Create : FileMode.CreateNew;
            using (var fileStream = new FileStream(context.TargetDockerfile, fileMode)) 
            {
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8)) 
                {
                    streamWriter.Write(content);
                } 
            }
        }

        private string CreateDockerFileContent(DockerfileContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# created by QuickCoreGenerator");
            sb.AppendLine($"FROM mcr.microsoft.com/dotnet/core/aspnet:{context.NetCoreVersion}-buster-slim AS base");
            sb.AppendLine("WORKDIR /app");
            if (context.HttpPort.HasValue)
            {
                sb.AppendLine($"EXPOSE {context.HttpPort}");
            }
            if (context.HttpsPort.HasValue)
            {
                sb.AppendLine($"EXPOSE {context.HttpsPort}");
            }
            sb.AppendLine("");
            sb.AppendLine($"FROM mcr.microsoft.com/dotnet/core/sdk:{context.NetCoreVersion}-buster AS build");
            sb.AppendLine("WORKDIR /src");
            sb.AppendLine("COPY . .");
            sb.AppendLine($"WORKDIR \"/src/{context.CsprojDir}\"");
            sb.AppendLine($"RUN dotnet build \"{context.CsprojName}\" -c {context.BuildMode} -o /app/build");
            sb.AppendLine("");
            sb.AppendLine("FROM build AS publish");
            sb.AppendLine($"RUN dotnet publish \"{context.CsprojName}\" -c {context.BuildMode} -o /app/publish");
            sb.AppendLine("");
            sb.AppendLine("FROM base AS final");
            sb.AppendLine("WORKDIR /app");
            sb.AppendLine("COPY --from=publish /app/publish .");

            sb.AppendLine(@"RUN mkdir /tmp/quickcore_tmp && \");
            sb.AppendLine(@"	mkdir /var/log/quickcore_log && \");
            sb.AppendLine(@"	mkdir /quickcore_data");
            sb.AppendLine("");
            sb.AppendLine("ENV App__TempFolder /tmp/quickcore_tmp");
            sb.AppendLine("ENV App__LogFolder /var/log/quickcore_log");
            sb.AppendLine("ENV App__DataFolder /quickcore_data");
            sb.AppendLine("");

            sb.AppendLine($"ENTRYPOINT [\"dotnet\", \"{context.EntryDllName}\"]");

            return sb.ToString();

        }
    }
}

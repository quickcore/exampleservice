using ServiceCenter.Core;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using QuickCore;

namespace ServiceCenter.Impl.File
{
    [ServiceClass()]
    public class FileServiceCenter : IServiceCenter
    {
        static JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
        public FileServiceCenter(IOptions<AppFolderOptions> option)
        {
            this.fileOption = option;
        }
        private IOptions<AppFolderOptions> fileOption;

        public void AddServiceInfo(ServiceInfo serviceInfo)
        {
            var filePath = GetDataFilePath(serviceInfo.Name, serviceInfo.Version);
            string folder = System.IO.Path.GetDirectoryName(filePath);
            System.IO.Directory.CreateDirectory(folder);
            var content = JsonConvert.SerializeObject(serviceInfo, Formatting.Indented, serializerSettings);
            System.IO.File.WriteAllText(filePath, content);
           
        }

        public void DeleteServiceInfo(string name, string version)
        {
            var filePath = GetDataFilePath(name, version);
            System.IO.File.Delete(filePath);
        }

        public List<string> GetAllVerisonsByServiceName(string name)
        {
            string folderPath = GetDataFolderPath(name);
            if (System.IO.Directory.Exists(folderPath))
            {
                var allVersionFiles = System.IO.Directory.GetFiles(folderPath, "*.json", System.IO.SearchOption.TopDirectoryOnly);
                return allVersionFiles.Select(p => System.IO.Path.GetFileNameWithoutExtension(p)).ToList();
            }
            else
            {
                return new List<string>();
            }

        }

        public ServiceInfo GetServiceInfo(string name, string version)
        {
            var filePath = GetDataFilePath(name, version);
            if (System.IO.File.Exists(filePath))
            {
                string content = System.IO.File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<ServiceInfo>(content, serializerSettings);
            }
            else
            {
                return null;
            }
        }
        private string GetDataFilePath(string name, string version)
        {
            return System.IO.Path.Combine(this.fileOption.Value.DataFolder, name, $"{version}.json");
        }
        private string GetDataFolderPath(string name)
        {
            return System.IO.Path.Combine(this.fileOption.Value.DataFolder, name);
        }
    }
}

using System;
using System.Collections.Generic;

namespace ServiceCenter.Core
{
    public interface IServiceCenter
    {
        List<string> GetAllVerisonsByServiceName(string name);
        ServiceInfo GetServiceInfo(string name,string version);
        void AddServiceInfo(ServiceInfo serviceInfo);
        void DeleteServiceInfo(string name, string version);
    }
}

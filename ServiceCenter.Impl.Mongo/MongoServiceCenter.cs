using ServiceCenter.Core;
using System;
using System.Collections.Generic;

namespace ServiceCenter.Impl.Mongo
{
    [System.ServiceImplClass(typeof(IServiceCenter))]
    public class MongoServiceCenter : IServiceCenter
    {
        public void AddServiceInfo(ServiceInfo serviceInfo)
        {

        }

        public void DeleteServiceInfo(string name, string version)
        {

        }

        public List<string> GetAllVerisonsByServiceName(string name)
        {
            return new List<string>()
            {
                "1.0.0",
                "1.0.1"
            };
        }

        public ServiceInfo GetServiceInfo(string name, string version)
        {
            return new ServiceInfo()
            {
                Name = name,
                Version = version
            };
        }
    }
}

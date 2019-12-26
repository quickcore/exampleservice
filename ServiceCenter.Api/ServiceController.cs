using Knife.Api;
using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Core;
using System.Collections.Generic;

namespace ServiceCenter.Api
{
    public class ServiceController : ApiBase<IServiceCenter>,IServiceCenter
    {
        [HttpPost]
        public void AddServiceInfo(ServiceInfo serviceInfo)
        {
            this.Delegater.AddServiceInfo(serviceInfo);
        }
        [HttpDelete]
        [Route("{name}/{version}")]
        public void DeleteServiceInfo(string name, string version)
        {
            this.Delegater.DeleteServiceInfo(name, version);
        }
        [HttpGet]
        [Route("{name}/versions")]
        public List<string> GetAllVerisonsByServiceName(string name)
        {
            return this.Delegater.GetAllVerisonsByServiceName(name);
        }
        [HttpGet]
        [Route("{name}/{version}")]
        public ServiceInfo GetServiceInfo(string name, string version)
        {
            return this.Delegater.GetServiceInfo(name, version);
        }
    }
}

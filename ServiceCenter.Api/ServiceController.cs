using Microsoft.AspNetCore.Mvc;
using QuickCore.Api;
using ServiceCenter.Core;
using System;
using System.Collections.Generic;

namespace ServiceCenter.Api
{
    public class ServiceController : ApiBase<IServiceCenter>
    {
        [HttpPost]
        public void AddServiceInfo(ServiceInfo serviceInfo)
        {
            this.Instance.AddServiceInfo(serviceInfo);
        }
        [HttpDelete]
        [Route("{name}/{version}")]
        public void DeleteServiceInfo(string name, string version)
        {
            this.Instance.DeleteServiceInfo(name, version);
        }
        [HttpGet]
        [Route("{name}/versions")]
        public List<string> GetAllVerisonsByServiceName(string name)
        {
            return this.Instance.GetAllVerisonsByServiceName(name);
        }
        [HttpGet]
        [Route("{name}/{version}")]
        public ServiceInfo GetServiceInfo(string name, string version)
        {
            return this.Instance.GetServiceInfo(name, version);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace QuickCore.Api
{
    [ApiController]
    [Route("[controller]")]
    public  class ApiBase:ControllerBase
    {
        
    }
    public class ApiBase<T> : ApiBase
        where T:class
    {
        public ApiBase()
        {
            this.instanceFactory = new Lazy<T>(() => this.HttpContext.RequestServices.GetRequiredService<T>());
        }
        private Lazy<T> instanceFactory ;
        protected T Instance { get { return instanceFactory.Value; } }
    }
}

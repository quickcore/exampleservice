using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

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
        public ApiBase(T instance)
        {
            this.Instance = instance;
        }
        protected T Instance { get; private set; }
    }
}

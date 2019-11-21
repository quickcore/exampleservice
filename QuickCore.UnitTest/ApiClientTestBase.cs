using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore.UnitTest
{
    public class ApiClientTestBase<TC, TI>
        where TC : Client.ClientBase<TI>, TI
        where TI : class
    {
        public ApiClientTestBase()
        {
            var builder = new WebHostBuilder().UseStartup<Startup>();
            var testServer = new TestServer(builder);
            
        }
        private Lazy<TC> instanceFactor;
        protected TI Instance { get { return instanceFactor.Value; } }
    }
}

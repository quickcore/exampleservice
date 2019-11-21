using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using QuickCore.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace QuickCore.UnitTest
{
    public abstract class ApiClientTestBase<TC, TI>
        where TC : ClientBase<TI>, TI
        where TI : class
    {
        public ApiClientTestBase()
        {
            this.webHostBuilder = this.OnCreateWebHostBuilder();
            this.webHostBuilder.ConfigureServices(serviceCollections =>
            {
                serviceCollections.AddSingleton(typeof(IHttpClientFactory), (sp) =>
                {
                    return new TestHttpClientFactory(this.testServer);
                });
                serviceCollections.AddSingleton(typeof(TC));
            });
            this.testServer = new TestServer(webHostBuilder);
          

        }
        private TestServer testServer;
        private IWebHostBuilder webHostBuilder;
        protected abstract IWebHostBuilder OnCreateWebHostBuilder();
        protected TI Instance
        {
            get
            {
                return this.testServer.Host.Services.GetRequiredService<TC>();
            }
        }

        protected class TestHttpClientFactory : IHttpClientFactory

        {
            public TestHttpClientFactory(TestServer testServer)
            {
                this.testServer = testServer;
            }
            private TestServer testServer;

            public HttpClient CreateClient(string name)
            {
                return testServer.CreateClient();
            }
        }
    }
}

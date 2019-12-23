using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace QuickCore.Base
{
    public class AppServiceContext : IServiceProvider
    {
        public AppServiceContext()
        {
            this.BuildConfiguration();
            this.LoadPlugins();
            this.BuildServiceProvider();
           
        }
        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        private Assembly[] plugins;
        public object GetService(Type serviceType)
        {
            return this.ServiceProvider.GetService(serviceType);
        }
        private void LoadPlugins()
        {
            var appOptions = this.Configuration.GetConfigOrNew<AppOptions>();
            string rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            plugins = PluginLoader.LoadPlugins(rootPath, appOptions.Plugins);
        }
        private void BuildServiceProvider()
        {
            this.ServiceProvider = new ServiceCollection().RegisteServices(this.plugins, this.Configuration)
                              .RegisteOptions(this.plugins, this.Configuration)
                              .BuildServiceProvider();
        }
        private void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder();

            this.Configuration = builder.Build();
        }

    }
}

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace QuickCore
{
    public class QuickCore
    {
        public static IHost CreateHost(string[] args = default)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices((builder, serviceCollection) =>
            {
                var options = builder.Configuration.GetConfigOrNew<AppOptions>();

                var plugins = PluginLoader.LoadPlugins(builder.HostingEnvironment.ContentRootPath, options.Plugins);

                serviceCollection.RegisteServices(plugins, builder.Configuration);
                
                serviceCollection.RegisteOptions(plugins, builder.Configuration);
               
               
            }).Build();
        }
        public static IHost CreateHost<T>(string[] args = default)
            where T : IHostedService
        {
            return new HostBuilder().Build();
        }
    }
}

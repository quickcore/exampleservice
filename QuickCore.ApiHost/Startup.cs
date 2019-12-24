using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace QuickCore.ApiHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.appOption = configuration.GetConfigOrNew<WebAppOptions>();

            this.LoadPlugins();
        }
        private void LoadPlugins()
        {
            string rootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            plugins = PluginLoader.LoadPlugins(rootPath, this.appOption.Plugins);
        }
        private WebAppOptions appOption;
        private Assembly[] plugins;
        private IConfiguration configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisteServices(this.plugins, this.configuration)
                .RegisteOptions(this.plugins, this.configuration);
            IMvcBuilder mvcBuilder = services.AddControllers((mvc) =>
              {

              });

            foreach (var assembly in plugins)
            {
                var assName = assembly.GetName().Name;
                if( assName.IsMatchWildcardAnyOne(appOption.MvcParts, StringComparison.OrdinalIgnoreCase))
                {
                    mvcBuilder.AddApplicationPart(assembly);
                }
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

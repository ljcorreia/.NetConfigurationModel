using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace NetCoreDetectConfigChangesWithMonitor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddFormatterMappings()
                .AddJsonFormatters();

            services.AddSingleton<IConfigurationMonitor, ConfigurationMonitor>();
            //services.Configure<VersionConfig>(Configuration);
            services.Configure<VersionConfig>(Configuration.GetSection("VersionConfig"));

            //To not use IOptions to resolve dependency add Scoped value directly as shown below
            //services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<VersionConfig>>().Value);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

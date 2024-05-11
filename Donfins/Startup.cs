using Dofins.Context;
using Dofins.Interfaces;
using Dofins.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Dofins
{
    
    
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRealtime, RealtimeServices>();
            services.AddTransient<IAuthentication, AuthenticationServices>();

            services.AddControllersWithViews();
            services.AddRazorPages();
/*            services.AddDbContext<HandleDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Postgres"));
            });
*/
            services.AddSingleton<IConnectionMultiplexer>(provider =>
            {
                var configuration = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(configuration);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}


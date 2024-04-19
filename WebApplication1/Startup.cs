using WebApplication1.Interfaces;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add other services
            services.AddTransient<IRealtime, RealtimeServices>();
            // Add authentication service if needed
            services.AddTransient<IAuthentication, AuthenticationServices>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }
    }
}

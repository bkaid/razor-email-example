using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Notification.Infrastructure.Razor;

namespace Notification
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<IViewRenderer, RazorViewRenderer>()
                .AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
        }
    }
}

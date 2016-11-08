using Microsoft.AspNetCore.Builder;
using Nancy;
using Nancy.Owin;

namespace NancyApplication
{
    public class Startup
    {
        public  void Configure(IApplicationBuilder app)
        {
            

            app.UseOwin(x => x.UseNancy());
        
            // app.UseStaticFiles();
        }
    }
}
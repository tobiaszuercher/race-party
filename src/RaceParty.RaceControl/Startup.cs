using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

using Nancy.Owin;

namespace RaceParty.RaceControl
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            loggerFactory.WithFilter(new FilterLoggerSettings
                {
                    { "Microsoft", LogLevel.Warning },
                    { "System", LogLevel.Warning },
                    { "ToDoApi", LogLevel.Debug }
                });

            MyNancyBootStrapper.LogFactory = loggerFactory; // LOL

   
            app.UseDeveloperExceptionPage();
  

            app.UseOwin(x => x.UseNancy());

            
        }
    }
}
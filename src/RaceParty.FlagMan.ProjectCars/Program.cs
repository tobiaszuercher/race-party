using System;

using FluentScheduler;
using Microsoft.Extensions.Logging;

using SimpleInjector;

namespace RaceParty.FlagMan.ProjectCars
{
    public class Program
    {
        private static ILogger Log;

        public static void Main(string[] args)
        {
            var logFactory = InitializeLogginging();

            var container = new Container();
            container.RegisterSingleton(logFactory);
            container.RegisterSingleton(new RecordLapTimesJobState());
            container.RegisterSingleton(new RaceControlClient("http://localhost:5000", logFactory));

            Log.LogInformation("Starting FlagMan for project cars...");
            
            var registry = new Registry();
            registry.Schedule<RecordLapTimesJob>().NonReentrant().ToRunEvery(2).Seconds();

            JobManager.JobFactory = new SimpleInjectorJobFactory(container);
            JobManager.Initialize(registry);

            Log.LogInformation("Press esc to exit.");

            while (true)
            {
                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.Escape)
                    Environment.Exit(0);
            }
        }

        private static ILoggerFactory InitializeLogginging()
        {
            var factory = new LoggerFactory()
                .WithFilter(new FilterLoggerSettings
                {
                    { "Microsoft", LogLevel.Warning },
                    { "System", LogLevel.Warning },
                    { "RaceParty.FlagMan.ProjectCars.Program", LogLevel.Debug }
                });

            factory.AddConsole();
            
            Log = factory.CreateLogger<Program>();

            return factory;
        }
    }
}

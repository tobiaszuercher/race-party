using System;
using System.Diagnostics;
using System.IO;

using FluentScheduler;

using ServiceStack;

namespace RaceParty.FlagMan.ProjectCars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Race Party");
            var registry = new Registry();
            //registry.Schedule<RecordLapTimesOnButtonPressJob>().ToRunNow();

            //JobManager.Initialize(registry);

            var counter = 0;
            var session = DateTime.Now.ToString("hh-mm-ss");
        
            while (true)
            {
                var input = Console.ReadKey();  

                if (input.Key == ConsoleKey.Spacebar)
                {
                    var filename = $"data/{session}_{counter:000}.json";

                    var watch = new Stopwatch();
                    watch.Start();
                    File.WriteAllText(filename, "http://192.168.1.15:8080/crest/v1/api?timings=true&vehicleInformation=true&eventInformation=true".GetStringFromUrl());
                    watch.Stop();

                    Console.WriteLine($"Writing {filename} in {watch.ElapsedMilliseconds} ms.");

                    //Console.WriteLine("gugus " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                }
                else if (input.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Finish!");

                    Environment.Exit(0);
                }

                ++counter;
            }
        }
    }
}

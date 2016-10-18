using System;

using FluentScheduler;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Race Party");
            var registry = new Registry();
            registry.Schedule<MyJob>().ToRunNow().AndEvery(2).Seconds();
            registry.Schedule<MySecondJob>().ToRunNow().AndEvery(3).Seconds();

            JobManager.Initialize(registry);
            
            Console.WriteLine("Press enter to stop");
            Console.ReadLine();

            Environment.Exit(0);
        }
    }

    public class MyJob : IJob
    {
        public void Execute()
        {
            Console.WriteLine("gugus " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
    }

    public class MySecondJob : IJob
    {
        public void Execute()
        {
            Console.WriteLine("zweiti job: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
    }
}

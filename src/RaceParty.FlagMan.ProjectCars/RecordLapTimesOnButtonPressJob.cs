using System;
using System.IO;

using FluentScheduler;

using ServiceStack;

namespace RaceParty.FlagMan.ProjectCars
{
    public class RecordLapTimesOnButtonPressJob : IJob
    {
        public void Execute()
        {
            var input = Console.Read();

            while (true)
            {
                if (input == (int)ConsoleKey.Spacebar)
                {
                    Console.Write("space");
                    //Console.WriteLine("gugus " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                }
                else if (input == (int)ConsoleKey.Escape)
                {
                    Console.WriteLine("Finish!");
                    return;
                }
            }
        }
    }
}
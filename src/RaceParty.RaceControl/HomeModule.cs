using System;
using Nancy;
using RaceParty.RaceControl.Model;
using Raven.Client.Document;

namespace NancyApplication
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {

            Get("/", args => {
                Console.WriteLine("gugus");
                var store = new DocumentStore();
                
                
                store.Initialize();

                var e = new Event() { Name = "Game Event" };

                using(var session = store.OpenSession())
                {
                    session.Store(e);
                    session.SaveChanges();
                }
                
                return "wtf";
            });
        }
    }
}
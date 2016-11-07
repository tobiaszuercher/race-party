using System.Linq;

using Nancy;
using Nancy.Extensions;

using RaceParty.RaceControl.ServiceModel;

using ServiceStack;

namespace RaceParty.RaceControl
{
    public class LapTimesModule : NancyModule
    {
        private Raven.Client.IDocumentSession _session;

        public LapTimesModule(Raven.Client.IDocumentSession session)
        {
            _session = session;

            Get("/laptimes",
                args =>
                    {
                        return _session.Query<LapTime>().ToList();
                    });

            Post("/laptimes", args =>
            {
                var body = Request.Body.AsString();
                var laptime = body.FromJson<LapTime>();

                session.Store(laptime);
                session.SaveChanges();

                return HttpStatusCode.Created;
            });
        }
    }
}
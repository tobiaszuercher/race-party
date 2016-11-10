using Microsoft.Extensions.Logging;

using Nancy;
using Nancy.Bootstrapper;
using Nancy.Configuration;
using Nancy.TinyIoc;
using RaceParty.RaceControl.ServiceModel;

using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace RaceParty.RaceControl
{
    public class RacePartyNancyBootstrapper : DefaultNancyBootstrapper
    {
        public static ILoggerFactory LogFactory { get; set; }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(GenerateRavenDocStore());
            container.Register(LogFactory);
            
            var factory = new OrmLiteConnectionFactory("race-party.sqlite", SqliteDialect.Provider);
            container.Register<IDbConnectionFactory>(factory);
            
            using (var db = factory.Open())
            {
                db.CreateTableIfNotExists<Driver>();
                db.CreateTableIfNotExists<LapTime>();
            }
        }

        private Raven.Client.IDocumentStore GenerateRavenDocStore()
        {
            var docstore = new Raven.Client.Document.DocumentStore
                               {
                                   Url = "http://localhost:8081/",
                                   DefaultDatabase = "tobi-test",
                                   ApiKey = "tobi/SukWxO6ne9By0hCawMFAc"
                               };

            docstore.Initialize();

            return docstore;
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register(GenerateRavenSession(container));

        }

        private Raven.Client.IDocumentSession GenerateRavenSession(TinyIoCContainer container)
        {
            var store = container.Resolve<Raven.Client.IDocumentStore>();
            var session = store.OpenSession();

            return session;
        }

        public override void Configure(INancyEnvironment environment)
        {
            base.Configure(environment);
            environment.Tracing(enabled: false, displayErrorTraces: true);
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            //CORS Enable
            pipelines.AfterRequest.AddItemToEndOfPipeline(
                (ctx) =>
                    {
                        ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                            .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                            .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
                    });
        }
    }
}

using Microsoft.Extensions.Logging;

using Nancy;
using Nancy.TinyIoc;

namespace RaceParty.RaceControl
{
    public class MyNancyBootStrapper : DefaultNancyBootstrapper
    {
        public static ILoggerFactory LogFactory { get; set; }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(GenerateRavenDocStore());
            container.Register(LogFactory);
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
    }
}

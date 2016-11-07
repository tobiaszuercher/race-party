
namespace RaceParty.RaceControl
{
    public class MyNancyBootStrapper : Nancy.DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(
            Nancy.TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(GenerateRavenDocStore());
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

        protected override void ConfigureRequestContainer(
            Nancy.TinyIoc.TinyIoCContainer container, Nancy.NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register(GenerateRavenSession(container));
        }

        private Raven.Client.IDocumentSession GenerateRavenSession(
            Nancy.TinyIoc.TinyIoCContainer container)
        {
            var store = container.Resolve<Raven.Client.IDocumentStore>();
            var session = store.OpenSession();

            return session;
        }
    }
}

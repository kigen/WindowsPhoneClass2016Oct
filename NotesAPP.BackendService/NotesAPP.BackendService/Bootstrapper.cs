using System.Data.Entity;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace NotesAPP.BackendService
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            Database.SetInitializer(new CreateDatabaseIfNotExists<NotesDbContext>());
        }
    }
}
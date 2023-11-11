using EasyMicroservices.CommentsMicroservice.Database.Contexts;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using EasyMicroservices.CommentsMicroservice;

namespace EasyMicroservices.CommentsMicroservice.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = CreateBuilder(args);
            var build = await app.Build<CommentContext>(true);
            build.MapControllers();
            build.Run();
        }

        static WebApplicationBuilder CreateBuilder(string[] args)
        {
            var app = StartUpExtensions.Create<CommentContext>(args);
            app.Services.Builder<CommentContext>();
            app.Services.AddTransient((serviceProvider) => new UnitOfWork(serviceProvider));
            app.Services.AddTransient(serviceProvider => new CommentContext(serviceProvider.GetService<IEntityFrameworkCoreDatabaseBuilder>()));
            app.Services.AddTransient<IEntityFrameworkCoreDatabaseBuilder, DatabaseBuilder>();
            StartUpExtensions.AddWhiteLabel("Questions", "RootAddresses:WhiteLabel");
            return app;
        }

        public static async Task Run(string[] args, Action<IServiceCollection> use)
        {
            var app = CreateBuilder(args);
            use?.Invoke(app.Services);
            var build = await app.Build<CommentContext>();
            build.MapControllers();
            build.Run();
        }
    }
}
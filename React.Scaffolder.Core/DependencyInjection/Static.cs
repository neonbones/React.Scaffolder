using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using React.Scaffolder.Core.Interfaces;
using React.Scaffolder.Core.Scaffolders;
using React.Scaffolder.Core.Scaffolders.Redux;
using React.Scaffolder.Core.Scaffolders.Redux.Implementation;
using React.Scaffolder.Domain.Options;

namespace React.Scaffolder.Core.DependencyInjection
{
    public static class Static
    {
        public static IServiceProvider ServiceProvider;

        static Static()
        {
            Configuration = LoadConfiguration();
        }

        public static IConfiguration Configuration { get; }

        public static void RegisterServices()
        {
            var sc = new ServiceCollection();

            sc.AddOptions();
            sc.Configure<GlobalSettings>(Configuration.GetSection("GlobalSettings"));
            sc.Configure<EntitySettings>(Configuration.GetSection("EntitySettings"));

            sc.AddTransient<IScaffolder, Scaffolder>();
            sc.AddTransient<ServiceScaffolder>();
            sc.AddTransient<ReduxScaffolder>();
            sc.AddTransient<ConstantsScaffolder>();
            sc.AddTransient<ReducerScaffolder>();
            sc.AddTransient<ActionsScaffolder>();

            ServiceProvider = sc.BuildServiceProvider();
        }

        public static void DisposeServices()
        {
            switch (ServiceProvider)
            {
                case null:
                    return;
                case IDisposable disposable:
                    disposable.Dispose();
                    break;
            }
        }

        public static IConfiguration LoadConfiguration()
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ScaffolderSettings.json", false)
                .Build();
    }
}
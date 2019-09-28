using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using React.Scaffolder.Core.Interfaces;
using React.Scaffolder.Core.Models;
using React.Scaffolder.Core.Scaffolders;
using React.Scaffolder.Core.Scaffolders.Redux;
using React.Scaffolder.Core.Scaffolders.Redux.Implementation;
using React.Scaffolder.Infrastructure;
using React.Scaffolder.Infrastructure.Options;

namespace React.Scaffolder.Core.DependencyInjection
{
    public static class Static
    {
        public static IServiceProvider ServiceProvider;
        public static IConfiguration Configuration { get; }

        static Static()
        {
            Configuration = LoadConfiguration();
        }

        public static void RegisterServices()
        {
            var sc = new ServiceCollection();    

            sc.AddOptions();
            sc.Configure<GlobalSettings>(Configuration.GetSection("GlobalSettings"));
            sc.Configure<EntitySettings>(Configuration.GetSection("EntitySettings"));

            sc.AddTransient<IScaffolder, Scaffolder>();
            sc.AddTransient<FoldersHandler>();
            sc.AddTransient<ServiceScaffolder>();
            sc.AddTransient<ReduxScaffolder>();
            sc.AddTransient<ConstantsScaffolder>();

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
                    .AddJsonFile("appsettings.json", false)
                    .Build();
    }
}
using System;
using Microsoft.Extensions.DependencyInjection;
using React.Scaffolder.Core.DependencyInjection;
using React.Scaffolder.Core.Interfaces;

namespace React.Scaffolder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scaffolder started.");
            Static.RegisterServices();
            
            Static.ServiceProvider.GetService<IScaffolder>().Run();

            Static.DisposeServices();
            Console.WriteLine("Scaffolder finished.");
            Console.ReadKey();
        }
    }
}

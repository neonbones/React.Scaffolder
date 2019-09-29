using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using React.Scaffolder.Core.DependencyInjection;
using React.Scaffolder.Domain.Options;

namespace React.Scaffolder.Core.Scaffolders.Redux.Implementation.Base
{
    public abstract class ScaffolderAbstractions
    {
        protected ScaffolderAbstractions()
        {
            var e = Static.ServiceProvider.GetService<IOptions<EntitySettings>>();
            var g = Static.ServiceProvider.GetService<IOptions<GlobalSettings>>();

            UpperEnitity = e.Value.Entity.ToUpperInvariant();
            LowerEntity = e.Value.Entity.ToLowerInvariant();
            Fields = e.Value.Fields;
            ApiRoute = g.Value.ApiRoute;
            RootFolder = g.Value.RootFolder;
            Entity = e.Value.Entity;

            FieldsAsString = e.Value.Fields.Select(i => i.Name).Aggregate((i, j) => i + ", " + j);
        }

        public string UpperEnitity { get; }
        public string LowerEntity { get; }
        public string Entity { get; }
        public List<Field> Fields { get; }
        public string ApiRoute { get; }
        public string RootFolder { get; }
        public string FieldsAsString { get; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using React.Scaffolder.Core.Models;
using React.Scaffolder.Infrastructure;

namespace React.Scaffolder.Core.Scaffolders
{
    public class FoldersHandler : IHandler<string, Dictionary<FolderTypes, string>>
    {
        public Dictionary<FolderTypes, string> Handle(string root)
        {
            if (!Directory.Exists(root))
                throw new FileNotFoundException("Root directory not found.");

            var feature = root.Cd("src").Cd("features") + @"\posts";
            if (Directory.Exists(feature))
                throw new InvalidOperationException("Directory already exists.");

            Directory.CreateDirectory(feature);
            var features = FeatureDirectories(feature);
            foreach (var directory in FeatureDirectories(feature))
                Directory.CreateDirectory(directory.Value);

            return features;
        }

        public Dictionary<FolderTypes, string> FeatureDirectories(string folder)
            => new Dictionary<FolderTypes, string>
            {
                {FolderTypes.Containers, folder + @"\containers"},
                {FolderTypes.Redux, folder + @"\redux"},
                {FolderTypes.Schemas, folder + @"\schemas"},
                {FolderTypes.Views, folder + @"\views"}
            };
    }
}
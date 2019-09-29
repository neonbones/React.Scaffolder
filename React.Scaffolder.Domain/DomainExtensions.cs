using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using React.Scaffolder.Domain.Models;
using React.Scaffolder.Infrastructure;

namespace React.Scaffolder.Domain
{
    public static class DomainExtensions
    {
        public static Dictionary<FolderTypes, string> ToFeatures(this string root, string name)
        {
            if (!Directory.Exists(root))
                throw new FileNotFoundException("Root directory not found.");

            var feature = root.Cd("src").Cd("features") + $"\\{name}";
            if (Directory.Exists(feature))
                throw new InvalidOperationException($"Directory with name {feature} already exists.");

            var folders = new Dictionary<FolderTypes, string>
            {
                {FolderTypes.Containers, feature + @"\containers"},
                {FolderTypes.Redux, feature + @"\redux"},
                {FolderTypes.Schemas, feature + @"\schemas"},
                {FolderTypes.Views, feature + @"\views"}
            };

            folders.ForEach(x => Directory.CreateDirectory(x.Value));

            return folders;
        }

        public static string Cd(this string value, string folder)
        {
            var result = Directory.GetDirectories(value).FirstOrDefault(x => x.Contains(folder));
            if (result == null)
                throw new FileNotFoundException($"Folder with name {folder} not found.");
            return result;
        }
    }
}
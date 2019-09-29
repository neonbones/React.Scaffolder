using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using React.Scaffolder.Domain.Models;

namespace React.Scaffolder.Infrastructure
{
    public static class Extensions
    {
        public static string Cd(this string value, string folder)
        {
            var result = Directory.GetDirectories(value).FirstOrDefault(x => x.Contains(folder));
            if (result == null)
                throw new FileNotFoundException();
            return result;
        }

        public static Dictionary<FolderTypes, string> ToFeatures(this string root)
        {
            if (!Directory.Exists(root))
                throw new FileNotFoundException("Root directory not found.");

            var feature = root.Cd("src").Cd("features") + @"\posts";
            if (Directory.Exists(feature))
                throw new InvalidOperationException("Directory already exists.");

            return new Dictionary<FolderTypes, string>
            {
                {FolderTypes.Feature, feature},
                {FolderTypes.Containers, feature + @"\containers"},
                {FolderTypes.Redux, feature + @"\redux"},
                {FolderTypes.Schemas, feature + @"\schemas"},
                {FolderTypes.Views, feature + @"\views"}
            };
        }

        public static IEnumerable<T> ForEachInner<T>(this IEnumerable<T> inner, Action<T> a)
        {
            var array = inner.ToArray();
            foreach (var e in array) a(e);

            return array;
        }

        public static void ForEach<T>(this IEnumerable<T> inner, Action<T> a)
        {
            foreach (var e in inner) a(e);
        }

        public static void PipeToParallel<T>(this IEnumerable<T> inner, Action<T> a)
        {
            Parallel.ForEach(inner, a);
        }
    }
}

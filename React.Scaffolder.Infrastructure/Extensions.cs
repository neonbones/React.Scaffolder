using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

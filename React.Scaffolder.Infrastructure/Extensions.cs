using System.IO;
using System.Linq;

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
    }
}

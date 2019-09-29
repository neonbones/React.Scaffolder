using System.Collections.Generic;

namespace React.Scaffolder.Infrastructure.Options
{
    public class EntitySettings
    {
        public string Entity { get; set; }
        public List<Field> Fields { get; set; }
    }

    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}

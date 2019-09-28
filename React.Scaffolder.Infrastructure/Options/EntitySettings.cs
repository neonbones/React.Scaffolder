using System;
using System.Collections.Generic;
using System.Text;

namespace React.Scaffolder.Infrastructure.Options
{
    public class EntitySettings
    {
        public string Name { get; set; }

        public List<Field> Fields { get; set; }
    }

    public class Field
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }

    }
}

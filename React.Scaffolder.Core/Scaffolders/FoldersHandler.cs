using System;
using System.Collections.Generic;
using System.IO;
using React.Scaffolder.Domain.Models;
using React.Scaffolder.Infrastructure;

namespace React.Scaffolder.Core.Scaffolders
{
    public class FoldersHandler : IHandler<string, Dictionary<FolderTypes, string>>
    {
        public Dictionary<FolderTypes, string> Handle(string root)
            => new Dictionary<FolderTypes, string>(
                root.ToFeatures().ForEachInner(x => Directory.CreateDirectory(x.Value)));
    }
}
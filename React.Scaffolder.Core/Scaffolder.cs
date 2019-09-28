using System;
using Microsoft.Extensions.Options;
using React.Scaffolder.Core.Interfaces;
using React.Scaffolder.Core.Models;
using React.Scaffolder.Core.Scaffolders;
using React.Scaffolder.Core.Scaffolders.Redux;
using React.Scaffolder.Infrastructure;
using React.Scaffolder.Infrastructure.Options;

namespace React.Scaffolder.Core
{
    public class Scaffolder : IScaffolder
    {
        private readonly FoldersHandler _foldersHandler;
        private readonly ReduxScaffolder _reduxRootScaffolder;
        private readonly IOptions<GlobalSettings> _options;

        public Scaffolder(
            ReduxScaffolder reduxRootScaffolder, 
            FoldersHandler foldersHandler, 
            IOptions<GlobalSettings> options)
        {
            _reduxRootScaffolder = reduxRootScaffolder;
            _foldersHandler = foldersHandler;
            _options = options;
        }
        
        public void Run()
        {
            var rootFolder = _options.Value.RootFolder;

            foreach (var folder in rootFolder.PipeTo(_foldersHandler))
            {
                switch (folder.Key)
                {
                    case FolderTypes.Containers:
                        break;
                    case FolderTypes.Views:
                        break;
                    case FolderTypes.Redux:
                        _reduxRootScaffolder.Scaffold(folder.Value);
                        break;
                    case FolderTypes.Schemas:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }         
        }
    }
}

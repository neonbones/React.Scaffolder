using System;
using React.Scaffolder.Core.Interfaces;
using React.Scaffolder.Core.Scaffolders;
using React.Scaffolder.Core.Scaffolders.Redux;
using React.Scaffolder.Core.Scaffolders.Redux.Implementation.Base;
using React.Scaffolder.Domain.Models;
using React.Scaffolder.Infrastructure;

namespace React.Scaffolder.Core
{
    public class Scaffolder : ScaffolderAbstractions, IScaffolder
    {
        private readonly FoldersHandler _foldersHandler;
        private readonly ReduxScaffolder _reduxRootScaffolder;

        public Scaffolder(
            ReduxScaffolder reduxRootScaffolder,
            FoldersHandler foldersHandler)
        {
            _reduxRootScaffolder = reduxRootScaffolder;
            _foldersHandler = foldersHandler;
        }

        public void Run()
            => RootFolder.PipeTo(_foldersHandler).ForEach(x =>
            {
                switch (x.Key)
                {
                    case FolderTypes.Containers:
                        break;
                    case FolderTypes.Views:
                        break;
                    case FolderTypes.Redux:
                        _reduxRootScaffolder.Scaffold(x.Value);
                        break;
                    case FolderTypes.Schemas:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
    }
}
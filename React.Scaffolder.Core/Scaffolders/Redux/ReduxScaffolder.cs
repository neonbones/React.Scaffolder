using System.Collections.Generic;
using System.Threading.Tasks;
using React.Scaffolder.Core.Scaffolders.Redux.Implementation;
using React.Scaffolder.Infrastructure;

namespace React.Scaffolder.Core.Scaffolders.Redux
{
    public class ReduxScaffolder : IJavaScriptScaffolder<string>
    {
        public ReduxScaffolder(
            ServiceScaffolder service,
            ConstantsScaffolder constants,
            ReducerScaffolder reducer,
            ActionsScaffolder actions)
        {
            _scaffolders.Add(service);
            _scaffolders.Add(constants);
            _scaffolders.Add(reducer);
            _scaffolders.Add(actions);
        }

        private readonly List<IJavaScriptScaffolder<string>> _scaffolders =
            new List<IJavaScriptScaffolder<string>>();

        public void Scaffold(string folder) => _scaffolders.PipeToParallel(x => x.Scaffold(folder));
    }
}
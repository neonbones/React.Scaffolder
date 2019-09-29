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
            _reduxScaffolders.Add(service);
            _reduxScaffolders.Add(constants);
            _reduxScaffolders.Add(reducer);
            _reduxScaffolders.Add(actions);
        }

        private readonly List<IJavaScriptScaffolder<string>> _reduxScaffolders =
            new List<IJavaScriptScaffolder<string>>();

        public void Scaffold(string folder)
            => Parallel.ForEach(_reduxScaffolders, scaffolder => scaffolder.Scaffold(folder));
    }
}
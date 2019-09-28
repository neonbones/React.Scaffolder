using System.Collections.Generic;
using React.Scaffolder.Core.Scaffolders.Redux.Implementation;
using React.Scaffolder.Infrastructure;

namespace React.Scaffolder.Core.Scaffolders.Redux
{
    public class ReduxScaffolder : IJavaScriptScaffolder<string>
    {
        public List<IJavaScriptScaffolder<string>> ReduxScaffolders { get; protected set; } = new List<IJavaScriptScaffolder<string>>();

        public ReduxScaffolder(
            ServiceScaffolder serviceScaffolder, 
            ConstantsScaffolder constantsScaffolder,
            ReducerScaffolder reducerScaffolder)
        {
            ReduxScaffolders.Add(serviceScaffolder);
            ReduxScaffolders.Add(constantsScaffolder);
            ReduxScaffolders.Add(reducerScaffolder);
        }   

        public void Scaffold(string folder)
        {
            foreach (var javaScriptScaffolder in ReduxScaffolders)
            {
                javaScriptScaffolder.Scaffold(folder);
            }
        }
    }
}

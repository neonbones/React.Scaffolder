namespace React.Scaffolder.Infrastructure
{
    public interface IJavaScriptScaffolder<in TIn>
    {
        void Scaffold(TIn folder);
    }
}

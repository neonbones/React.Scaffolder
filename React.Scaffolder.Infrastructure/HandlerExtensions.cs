namespace React.Scaffolder.Infrastructure
{
    public static class HandlerExtensions
    {
        public static TResult PipeTo<TSource, TResult>(
            this TSource source, IHandler<TSource, TResult> queryHandler)
            => queryHandler.Handle(source);
    }
}

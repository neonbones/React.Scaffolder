namespace React.Scaffolder.Infrastructure
{
    public interface IHandler<in TIn, out TOut>
    {
        TOut Handle(TIn input);
    }
}

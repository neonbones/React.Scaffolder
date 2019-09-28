using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace React.Scaffolder.Infrastructure
{
    public interface IHandler<in TIn>
    {
        void Handle(TIn input);
    }

    public interface IHandler<in TIn, out TOut>
    {
        TOut Handle(TIn input);
    }

    public interface IAsyncHandler<in TIn, TOut>
    {
        Task<TOut> Handle(TIn input, CancellationToken cancellationToken);
    }
}

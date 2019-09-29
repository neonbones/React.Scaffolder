using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace React.Scaffolder.Infrastructure
{
    public static class FunctionalExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> inner, Action<T> a)
        {
            foreach (var e in inner) a(e);
        }

        public static void PipeToParallel<T>(this IEnumerable<T> inner, Action<T> a)
        {
            Parallel.ForEach(inner, a);
        }

        public static TResult PipeTo<TSource, TResult>(
            this TSource source, IHandler<TSource, TResult> queryHandler)
            => queryHandler.Handle(source);
    }
}
using System.Linq.Expressions;
using FunctionalUtilities.Monads.Option;

namespace FunctionalUtilities.Extensions;

public static class QueryableExtensions
{
    public static Option<T> FirstOrOption<T>(
        this IQueryable<T> source,
        CancellationToken cancellationToken = default)
        where T: class
    {
        return source.FirstOrDefault();
    }
    
    public static Option<T> FirstOrOption<T>(
        this IQueryable<T> source,
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
        where T: class
    {
        return source.FirstOrDefault(predicate);
    }
}
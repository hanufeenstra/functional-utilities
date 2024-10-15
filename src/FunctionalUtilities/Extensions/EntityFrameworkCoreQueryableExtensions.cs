using System.Linq.Expressions;
using FunctionalUtilities.Monads.Option;
using Microsoft.EntityFrameworkCore;

namespace FunctionalUtilities.Extensions;

public static class EntityFrameworkCoreQueryableExtensions
{
    public static async Task<Option<T>> FirstOrOptionAsync<T>(
        this IQueryable<T> source,
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
        where T: class
    {
        return await source.FirstOrDefaultAsync(predicate, cancellationToken);
    }
    
    public static async Task<Option<T>> FirstOrOptionAsync<T>(
        this IQueryable<T> source,
        CancellationToken cancellationToken = default)
        where T: class
    {
        return await source.FirstOrDefaultAsync(cancellationToken);
    }
}
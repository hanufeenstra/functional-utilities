using FunctionalUtilities.Errors;
using FunctionalUtilities.Monads.Result;

namespace FunctionalUtilities.Rules;

public abstract class AbstractAsyncRule
{
    protected const bool RulePassed = true;
    protected const bool RuleFailed = false;
    
    public string Title { get; protected set; } = "Business Rule Failed";
    public string Details { get; protected set; } = "Business Rule Failed";
    protected abstract Task<bool> Passed();
    
    public async Task<Result> Match(
        Func<Result> onSuccess,
        Func<Error, Result> onFailure)
    {
        return await Passed()
            ? onSuccess()
            : onFailure(Error.FromBusinessRule(this));
    }
}
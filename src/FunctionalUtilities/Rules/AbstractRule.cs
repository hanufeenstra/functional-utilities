using FunctionalUtilities.Errors;
using FunctionalUtilities.Monads.Result;

namespace FunctionalUtilities.Rules;

public abstract class AbstractRule
{
    protected const bool RulePassed = true;
    protected const bool RuleFailed = false;
    
    public string Title { get; protected set; } = "Business Rule Failed";
    public string Details { get; protected set; } = "Business Rule Failed";
    protected abstract bool Passed();
    
    public Result Match(
        Func<Result> onSuccess,
        Func<Error, Result> onFailure)
    {
        return Passed()
            ? onSuccess()
            : onFailure(Error.FromBusinessRule(this));
    }
}
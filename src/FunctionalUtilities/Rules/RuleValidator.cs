using FunctionalUtilities.Monads.Result;

namespace FunctionalUtilities.Rules;

public static class RuleValidator
{
    public static Task<Result> ResultFrom(AbstractAsyncRule rule)
    {
        return rule.Match(
            onSuccess: Result.Success,
            onFailure: Result.Error);
    }
    
    public static Result ResultFrom(AbstractRule rule)
    {
        return rule.Match(
            onSuccess: Result.Success,
            onFailure: Result.Error);
    }
}
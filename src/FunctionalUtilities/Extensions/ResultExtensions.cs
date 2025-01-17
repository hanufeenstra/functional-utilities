using FunctionalUtilities.MinimalApiProblemResults;
using FunctionalUtilities.Monads.Result;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtilities.Extensions;

public static class ResultExtensions
{
    public static IResult ToMinimalApiResult<T>(this Result<T> result, string createdUri = "")
    {
        return result.Type switch
        {
            ResultTypes.Ok => Results.Ok(result.Value),
            ResultTypes.Created => Results.Created(createdUri, result.Value),
            ResultTypes.Error => ProblemResults.Error(result.ErrorValue),
            ResultTypes.Conflict => ProblemResults.Conflict(result.ErrorValue),
            ResultTypes.Forbidden => ProblemResults.Forbid(),
            ResultTypes.NotFound => ProblemResults.NotFound(result.ErrorValue),
            ResultTypes.Validation => ProblemResults.Validation(result.ErrorValue),
            _ => throw new InvalidOperationException("No result type found to switch on")
        };
    }
    
    public static IResult ToMinimalApiResult(this Result result, string createdUri = "")
    {
        return result.Type switch
        {
            ResultTypes.Ok => Results.Ok(),
            ResultTypes.Created => Results.Created(createdUri, null),
            ResultTypes.Error => ProblemResults.Error(result.ErrorValue),
            ResultTypes.Conflict => ProblemResults.Conflict(result.ErrorValue),
            ResultTypes.Forbidden => ProblemResults.Forbid(),
            ResultTypes.NotFound => ProblemResults.NotFound(result.ErrorValue),
            ResultTypes.Validation => ProblemResults.Validation(result.ErrorValue),
            _ => throw new InvalidOperationException("No result type found to switch on")
        };
    }
}


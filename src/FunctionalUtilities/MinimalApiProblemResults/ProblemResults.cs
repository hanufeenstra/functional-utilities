using System.Net;
using FunctionalUtilities.Errors;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtilities.MinimalApiProblemResults;

public static class ProblemResults
{
    public static IResult Forbid()
    {
        return Results.Problem(
            "You do not have the correct role to perform this action", 
            null,
            (int) HttpStatusCode.Forbidden, 
            "Action not allowed",
            "https://httpstatuses.com/403"
        );
    }

    public static IResult TooLarge()
    {
        return Results.Problem(
            "File size must be less than 5MB", 
            null,
            (int) HttpStatusCode.RequestEntityTooLarge, 
            "File too large",
            "https://httpstatuses.com/413"
        );
    }

    public static IResult Error(Error error)
    {
        return Results.Problem(
            error.Detail, 
            null,
            (int) HttpStatusCode.BadRequest, 
            error.Title,
            "https://httpstatuses.com/400"
        );
    }
    
    public static IResult Conflict(Error error)
    {
        return Results.Problem(
            error.Detail, 
            null,
            (int) HttpStatusCode.Conflict, 
            error.Title,
            "https://httpstatuses.com/409"
        );
    }
    
    public static IResult NotFound(Error error)
    {
        return Results.Problem(
            error.Detail, 
            null,
            (int) HttpStatusCode.NotFound, 
            error.Title,
            "https://httpstatuses.com/404"
        );
    }

    public static IResult TooManyRecords(Error error)
    {
        return Results.Problem(
            error.Detail,
            null,
            (int) HttpStatusCode.RequestEntityTooLarge,
            "Too many records",
            "https://httpstatuses.com/413");
    }
    
    public static IResult Validation(Error error)
    {
        return Results.ValidationProblem(
            error.Errors,
            error.Detail,
            null,
            (int) HttpStatusCode.BadRequest,
            error.Title,
            "https://httpstatuses.com/400");
    }
}
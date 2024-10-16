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
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3"
        );
    }

    public static IResult TooLarge()
    {
        return Results.Problem(
            "File size must be less than 5MB", 
            null,
            (int) HttpStatusCode.RequestEntityTooLarge, 
            "File too large",
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.11"
        );
    }

    public static IResult Error(Error error)
    {
        return Results.Problem(
            error.Detail, 
            null,
            (int) HttpStatusCode.BadRequest, 
            error.Title,
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"
        );
    }
    
    public static IResult Conflict(Error error)
    {
        return Results.Problem(
            error.Detail, 
            null,
            (int) HttpStatusCode.Conflict, 
            error.Title,
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8"
        );
    }
    
    public static IResult NotFound(Error error)
    {
        return Results.Problem(
            error.Detail, 
            null,
            (int) HttpStatusCode.NotFound, 
            error.Title,
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4"
        );
    }

    public static IResult TooManyRecords(Error error)
    {
        return Results.Problem(
            error.Detail,
            null,
            (int) HttpStatusCode.RequestEntityTooLarge,
            "Too many records",
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.11");
    }
    
    public static IResult Validation(Error error)
    {
        return Results.ValidationProblem(
            error.Errors,
            error.Detail,
            null,
            (int) HttpStatusCode.BadRequest,
            error.Title,
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1");
    }

    public static IResult UnsupportedMediaType(Error error)
    {
        return Results.Problem(
            error.Detail,
            null,
            (int) HttpStatusCode.UnsupportedMediaType,
            error.Title,
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.13");
            
    }
}
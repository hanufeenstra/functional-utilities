using FunctionalUtilities.Errors;

namespace FunctionalUtilities.Monads.Result;

public sealed record Result<T>
{
    public T Value { get; private init; }
    public bool IsSuccess => !IsError;
    public bool IsError { get; private init; } = false;
    public Error ErrorValue { get; private init; } = Errors.Error.None;
    public ResultTypes Type { get; private init; }

    private Result() { }
    
    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Error(error);
    public static implicit operator T(Result<T> result) => result.Value;
    public static implicit operator Result<T>(Result result) => Error(result.ErrorValue);


    public static Result<T> Success(T value)
    {
        return new Result<T>
        {
            IsError = false,
            Value = value,
            Type = ResultTypes.Ok
        };
    }

    public static Result<T> Created(T value)
    {
        return new Result<T>
        {
            IsError = false,
            Value = value,
            Type = ResultTypes.Created
        };
    }

    public static Result<T> Error(Error error)
    {
        return new Result<T>
        {
            IsError = true,
            ErrorValue = error,
            Type = ResultTypes.Error
        };
    }
    
    public static Result<T> Conflict(Error error)
    {
        return new Result<T>
        {
            IsError = true,
            ErrorValue = error,
            Type = ResultTypes.Conflict
        };
    }
}

public sealed record Result
{
    public bool IsSuccess => !IsError;
    public bool IsError { get; private init; } = false;
    public Error ErrorValue { get; private init; } = Errors.Error.None;
    public ResultTypes Type { get; private init; }

    private Result() { }

    public static implicit operator Result(Error error) => Error(error);

    public static Result Success()
    {
        return new Result
        {
            IsError = false,
            Type = ResultTypes.Ok,
        };
    }

    public static Result Error(Error error)
    {
        return new Result
        {
            Type = ResultTypes.Error,
            ErrorValue = error,
            IsError = true,
        };
    }
    
    public static Result Conflict(Error error)
    {
        return new Result
        {
            IsError = true,
            ErrorValue = error,
            Type = ResultTypes.Conflict
        };
    }
}
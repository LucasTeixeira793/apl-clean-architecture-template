using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.Domain.Abstractions;

public class Result
{
    public Result()
    {
        IsSuccess = true;
        //Error = Error.None;
    }
    public Result(Error error)
    {
        IsSuccess = false;
        Error = error;
    }

    public bool IsSuccess { get; }
    public Error? Error { get; }

    public static Result Success() => new();
    public static Result Failure(Error error) => new(error);

    public static implicit operator Result(Error error) => new(error);

    public TResult Match<TResult>(
        Func<bool, TResult> success,
        Func<Error, TResult> failure
        )
    {
        return IsSuccess ? success(true) : failure(Error);
    }
}

public class Result<TValue> : Result
{
    public Result(TValue value) : base()
    {
        Data = value;
    }

    public Result(Error error) : base(error)
    {
        Data = default;
    }

    public TValue? Data { get; }

    public static Result<TValue> Success(TValue value) => new(value);
    public static new Result<TValue> Failure(Error error) => new(error);

    public static implicit operator Result<TValue>(TValue value) => new(value);
    public static implicit operator Result<TValue>(Error error) => new(error);

    public TResult Match<TResult>(
        Func<TValue, TResult> success,
        Func<Error, TResult> failure
        )
    {
        return IsSuccess ? success(Data!) : failure(Error);
    }
}

namespace CleanArchitecture.Domain.Abstractions;

public class Result
{
    public bool IsSuccess { get; }
    public List<Error> Errors { get; }

    protected Result(bool isSuccess, List<Error>? errors = null)
    {
        IsSuccess = isSuccess;
        Errors = errors ?? new();
    }

    public static Result Success() => new(true);

    public static Result Failure(params Error[] errors)
        => new(false, errors.ToList());

    public static implicit operator Result(Error error)
        => Failure(error);

    public static implicit operator Result(List<Error> errors)
        => Failure(errors.ToArray());

    public TResult Match<TResult>(
        Func<bool, TResult> success,
        Func<List<Error>, TResult> failure
        )
    {
        return IsSuccess ? success(true) : failure(Errors);
    }
}

public class Result<TValue> : Result
{
    public TValue? Data { get; }

    private Result(TValue value)
        : base(true)
    {
        Data = value;
    }

    private Result(List<Error> errors)
        : base(false, errors)
    {
        Data = default;
    }

    public static Result<TValue> Success(TValue value) => new(value);

    public static new Result<TValue> Failure(params Error[] errors)
        => new(errors.ToList());

    public static implicit operator Result<TValue>(TValue value)
        => Success(value);

    public static implicit operator Result<TValue>(List<Error> errors)
        => Failure(errors.ToArray());

    public TResult Match<TResult>(
        Func<TValue, TResult> success,
        Func<List<Error>, TResult> failure
        )
    {
        return IsSuccess ? success(Data!) : failure(Errors);
    }
}
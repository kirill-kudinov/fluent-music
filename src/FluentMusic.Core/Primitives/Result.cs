using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FluentMusic.Core.Primitives;

public readonly record struct Result<T>
{
    private readonly T? _value;
    public readonly bool IsOK;
    public readonly bool isError => !IsOK;
    public readonly Error Error;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Result(in T? value)
    {
        _value = value;
        IsOK = true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Result(in Error error)
    {
        Error = error;
        IsOK = false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetOk([NotNullWhen(true)] out T? value)
    {
        value = _value;
        return IsOK;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Result<T>(FailedResult failedResult) => new(failedResult.Error);
}

public readonly record struct FailedResult
{
    internal Error Error { get; }
    internal FailedResult(Error error) => Error = error;
}

public static class Result
{
    private static readonly Result<Unit> OkUnit = new(Unit.Value);
    public static Task<Result<Unit>> OkTask { get; } = Task.FromResult(OkUnit);
    public static Result<Unit> Ok() => OkUnit;
    public static Task<Result<Unit>> NullValueTask { get; } =
        Task.FromResult<Result<Unit>>(Error(ResultErrors.NullValue));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FailedResult Error(in Error? error)
    {
        return error is null
            ? Error(ResultErrors.NullError)
            : new FailedResult(error);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<T> Ok<T>(in T value)
    {
        if (value is null)
        {
            return new FailedResult(ResultErrors.NullValue); 
        }

        return new Result<T>(in value); 
    }
}
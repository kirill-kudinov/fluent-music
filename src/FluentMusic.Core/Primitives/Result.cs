using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FluentMusic.Core.Primitives;

internal enum State : byte
{
    Ok,
    Fail
}

public readonly record struct Result<T>
{
    private readonly T? _value;
    private readonly State _state;
    private readonly Error _error;
    public readonly bool IsOk => _state == State.Ok;
    public readonly bool IsError => _state == State.Fail;

    public Error Error => _state switch
    {
        State.Ok => Error.None,
        State.Fail => _error,
        _ => ResultErrors.NullValue
    };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Result(in T? value)
    {
        _value = value;
        _state = State.Ok;
        _error = Error.None;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Result(in Error error)
    {
        _error = error.Code is null ? ResultErrors.NullValue : error; 
        _state = State.Fail;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetOk([NotNullWhen(true)] out T? value)
    {
        value = _value;
        return IsOk;
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FailedResult Fail(in Error? error)
    {
        return error is null
            ? new FailedResult(ResultErrors.NullValue)
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
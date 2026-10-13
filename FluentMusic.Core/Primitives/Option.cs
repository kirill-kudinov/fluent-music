using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace FluentMusic.Core.Primitives;

public readonly record struct Option<T>
{
    private readonly T? _value;
    public readonly bool HasValue;
    public readonly bool IsNone => !HasValue;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Option(in T value)
    {
        _value = value;
        HasValue = true;
    }

    public bool TryGetSome([NotNullWhen(true)]out T? value)
    {
        value = _value;
        return HasValue; 
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Option<T>(NoneToken _) => new();
}

public readonly record struct NoneToken
{
}

public static class Option
{
    public static NoneToken None
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Some<T>(in T? value)
    {
        if (value is not null) return new Option<T>(in value);

        return Cache<T>.NoneInstance;
    }

    internal static class Cache<T>
    {
        public static readonly Option<T> NoneInstance = default;
    }
}
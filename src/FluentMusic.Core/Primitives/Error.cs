using System.Runtime.CompilerServices;

namespace FluentMusic.Core.Primitives;

public readonly record struct Error
{
    public string Code { get; }
    public string Message { get; }

    public static readonly Error None = new(string.Empty, string.Empty);

    public bool IsNone
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => string.IsNullOrEmpty(Code);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Error(string code, string message)
    {
        Code = code ?? string.Empty;
        Message = message ?? string.Empty;
    }
}
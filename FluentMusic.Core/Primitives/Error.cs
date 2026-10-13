namespace FluentMusic.Core.Primitives;

public record Error
{
    public string Code { get; }
    public string Message { get; }
    public static Error None => new(string.Empty, string.Empty);

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
}
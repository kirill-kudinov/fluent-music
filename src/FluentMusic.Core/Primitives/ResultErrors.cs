namespace FluentMusic.Core.Primitives;

public static class ResultErrors
{
    public static readonly Error NullValue =
        new("Result.NullValue", "Попытка инициализировать Result значением null.");

    public static readonly Error Uninitialized =
        new("Result.Uninitialized", "Структура Result не была инициализирована (default).");
}
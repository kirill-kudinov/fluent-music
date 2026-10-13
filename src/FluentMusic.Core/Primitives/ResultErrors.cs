namespace FluentMusic.Core.Primitives;

public static class ResultErrors
{
    public static Error NullValue =
        new("Result.NullValue", "Попытка инициализировать успешный результат null значением.");

    public static Error NullError =
        new Error("Result.NullError", "Попытка инициализировать объект ошибки null значениями.");
}
namespace FluentMusic.Core.Primitives;

public static class ResultErrors
{
    public static Error NullValue =
        new("Result.NullValue", "Попытка инициализировать null значением.");
    
}
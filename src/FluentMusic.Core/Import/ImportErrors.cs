using FluentMusic.Core.Primitives;

namespace FluentMusic.Core.Import;

public class ImportErrors
{
    public static readonly Error EmptyFilePath =
        new("Music.EmptyFilePath", "Путь к аудиофайлу не может быть пустым.");

    public static readonly Error FileNotFound =
        new("Music.FileNotFound", "Файл или директория не найдены на устройстве.");

    public static readonly Error ImportCancelled =
        new("Import.Cancelled", "Импорт файлов был отменен или подходящие аудиофайлы не найдены.");
}
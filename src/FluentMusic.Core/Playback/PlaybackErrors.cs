using FluentMusic.Core.Primitives;

namespace FluentMusic.Core.Playback;

public static class PlaybackErrors
{
    public static readonly Error MediaEngineNotAttached =
        new("Playback.EngineNotAttached", "Аудиодвижок MediaElement не инициализирован.");
}
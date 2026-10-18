using FluentMusic.Core.Primitives;

namespace FluentMusic.Core.Albums;

public static class AlbumsError
{
    public static readonly Error DuplicateTrack =
        new("Albums.DuplicateTrack", "Этот трек уже присутствует в альбоме.");

    public static readonly Error TrackNotFound =
        new("Albums.TrackNotFound", "Трек не найден.");

    public static readonly Error InvalidPlaylistName =
        new("Albums.InvalidPlaylistName", "Название альбома не может быть пустым.");

    public static readonly Error CannotRenameSystemPlaylist =
        new("Albums.CannotRenameSystemPlaylist", "Стандартный плейлист «Избранное» нельзя переименовать.");
}
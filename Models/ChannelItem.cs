
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BeautyifyMAUI.Models;

public class ChannelItem : INotifyPropertyChanged
{
    private static readonly Color FavOff = Color.FromArgb("#C7CEDA");
    private static readonly Color FavOn = Color.FromArgb("#E5342B");

    public required string Abbrev { get; init; }
    public required Color TileColor { get; init; }
    public required string Name { get; init; }
    public required string CurrentProgram { get; init; }
    public double Progress { get; init; }
    public int Number { get; init; }
    public bool IsLive { get; init; }
    public bool IsHd { get; init; }

    public string NumberText => Number.ToString();

    private bool _isFavorite;
    public bool IsFavorite
    {
        get => _isFavorite;
        set
        {
            if (_isFavorite == value) return;
            _isFavorite = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FavoriteColor));
        }
    }

    public Color FavoriteColor => IsFavorite ? FavOn : FavOff;

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}



using CommunityToolkit.Mvvm.ComponentModel;

namespace BeautyifyMAUI.Models;

public partial class ChannelItem : ObservableObject
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

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FavoriteColor))]
    private bool _isFavorite;

    public Color FavoriteColor => IsFavorite ? FavOn : FavOff;
}

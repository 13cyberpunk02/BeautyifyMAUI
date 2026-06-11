
using CommunityToolkit.Mvvm.ComponentModel;

namespace BeautyifyMAUI.Models;

public partial class FilterChip : ObservableObject
{
    private static readonly Color SelectedBg = Color.FromArgb("#1B66E5");
    private static readonly Color NormalBg = Colors.White;
    private static readonly Color SelectedFg = Colors.White;
    private static readonly Color NormalFg = Color.FromArgb("#15191E");

    public required string Id { get; init; }
    public required string Title { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ChipColor))]
    [NotifyPropertyChangedFor(nameof(ChipTextColor))]
    private bool _isSelected;

    public Color ChipColor => IsSelected ? SelectedBg : NormalBg;
    public Color ChipTextColor => IsSelected ? SelectedFg : NormalFg;
}


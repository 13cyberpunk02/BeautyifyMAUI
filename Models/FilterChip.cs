
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BeautyifyMAUI.Models;

public class FilterChip : INotifyPropertyChanged
{
    private static readonly Color SelectedBg = Color.FromArgb("#1B66E5");
    private static readonly Color NormalBg = Colors.White;
    private static readonly Color SelectedFg = Colors.White;
    private static readonly Color NormalFg = Color.FromArgb("#15191E");

    public required string Id { get; init; }
    public required string Title { get; init; }

    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected == value) return;
            _isSelected = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ChipColor));
            OnPropertyChanged(nameof(ChipTextColor));
        }
    }

    public Color ChipColor => IsSelected ? SelectedBg : NormalBg;
    public Color ChipTextColor => IsSelected ? SelectedFg : NormalFg;

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}


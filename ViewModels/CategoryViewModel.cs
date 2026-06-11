
using BeautyifyMAUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BeautyifyMAUI.ViewModels;

public partial class CategoryViewModel : ObservableObject
{
    private static readonly Color BlueTint = Color.FromArgb("#E4EDFC");
    private static readonly Color RedTint = Color.FromArgb("#FCE7E6");
    private static readonly Color Blue = Color.FromArgb("#1B66E5");
    private static readonly Color Red = Color.FromArgb("#E5342B");

    public ObservableCollection<CategoryItem> Categories { get; } = new()
    {
        new() { Id = "all",      Title = "Все каналы",     Glyph = "\ue5c3", Tint = BlueTint, IconColor = Blue, Count = 99 },
        new() { Id = "sport",    Title = "Спорт",          Glyph = "\uea2f", Tint = RedTint,  IconColor = Red,  Count = 32 },
        new() { Id = "news",     Title = "Новости",        Glyph = "\ueb81", Tint = BlueTint, IconColor = Blue, Count = 24 },
        new() { Id = "movies",   Title = "Кино и сериалы", Glyph = "\ue684", Tint = RedTint,  IconColor = Red,  Count = 40 },
        new() { Id = "kids",     Title = "Детям",          Glyph = "\ueb41", Tint = BlueTint, IconColor = Blue, Count = 18 },
        new() { Id = "regional", Title = "Региональные",   Glyph = "\uf1db", Tint = RedTint,  IconColor = Red,  Count = 16 },
    };

    [ObservableProperty]
    private string _searchText = string.Empty;

    partial void OnSearchTextChanged(string value)
    {
        // TODO: живой поиск каналов и программ
    }

    [RelayCommand]
    private Task OpenCategoryAsync(CategoryItem item)
        => Shell.Current.GoToAsync($"channellist?category={item.Id}&title={item.Title}");

    [RelayCommand]
    private Task OpenFiltersAsync()
    {
        // TODO: страница/шторка фильтров
        return Task.CompletedTask;
    }

    [RelayCommand]
    private Task OpenProfileAsync()
        => Shell.Current.GoToAsync("//profile");
}

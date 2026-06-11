using BeautyifyMAUI.Models;
using System.Collections.ObjectModel;

namespace BeautyifyMAUI.Pages;

public partial class CategoryPage : ContentPage
{

    private static readonly Color BlueTint = Color.FromArgb("#E4EDFC");
    private static readonly Color RedTint = Color.FromArgb("#FCE7E6");
    private static readonly Color Blue = Color.FromArgb("#1B66E5");
    private static readonly Color Red = Color.FromArgb("#E5342B");

    public ObservableCollection<CategoryItem> Categories { get; } =
    [
        new() { Id = "all",      Title = "Все каналы",     Glyph = "\ue5c3", Tint = BlueTint, IconColor = Blue, Count = 99 },
        new() { Id = "sport",    Title = "Спорт",          Glyph = "\uea2f", Tint = RedTint,  IconColor = Red,  Count = 32 },
        new() { Id = "news",     Title = "Новости",        Glyph = "\ueb81", Tint = BlueTint, IconColor = Blue, Count = 24 },
        new() { Id = "movies",   Title = "Кино и сериалы", Glyph = "\ue684", Tint = RedTint,  IconColor = Red,  Count = 40 },
        new() { Id = "kids",     Title = "Детям",          Glyph = "\ueb41", Tint = BlueTint, IconColor = Blue, Count = 18 },
        new() { Id = "regional", Title = "Региональные",   Glyph = "\uf1db", Tint = RedTint,  IconColor = Red,  Count = 16 },
    ];


    public CategoryPage()
	{
		InitializeComponent();
        BindingContext = this;
    }

    private async void OnCategoryTapped(object? sender, TappedEventArgs e)
    {
        if ((sender as Element)?.BindingContext is not CategoryItem item)
            return;

        await Shell.Current.GoToAsync($"channellist?category={item.Id}&title={item.Title}");
    }

    private void OnSearchChanged(object? sender, TextChangedEventArgs e)
    {
        // TODO: фильтрация / переход к результатам поиска
    }

    private async void OnFilters(object? sender, TappedEventArgs e)
    {
        // TODO: открыть фильтры
        await Task.CompletedTask;
    }

    private async void OnProfile(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//profile");
    }
}
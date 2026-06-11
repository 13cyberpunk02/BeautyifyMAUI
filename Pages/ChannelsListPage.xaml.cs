using BeautyifyMAUI.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BeautyifyMAUI.Pages;

[QueryProperty(nameof(CategoryId), "category")]
[QueryProperty(nameof(CategoryTitle), "title")]

public partial class ChannelsListPage : ContentPage, INotifyPropertyChanged
{

    public string CategoryId { get; set; } = "";

    private string _categoryTitle = "Каналы";
    public string CategoryTitle
    {
        get => _categoryTitle;
        set { _categoryTitle = value; OnPropertyChanged(); }
    }

    public ObservableCollection<FilterChip> Filters { get; } = new()
    {
        new() { Id = "all",  Title = "Все 32",      IsSelected = true },
        new() { Id = "live", Title = "Эфир сейчас" },
        new() { Id = "hd",   Title = "HD" },
    };

    public ObservableCollection<ChannelItem> Channels { get; } = new();

    // Полный список (для фильтрации). Позже заменится данными с API.
    private readonly List<ChannelItem> _allChannels = new()
    {
        new() { Abbrev = "ПО", TileColor = Color.FromArgb("#1B66E5"), Name = "Первый Областной", CurrentProgram = "Утро в регионе",          Progress = 0.62, Number = 101, IsLive = true,  IsHd = true  },
        new() { Abbrev = "СП", TileColor = Color.FromArgb("#E5342B"), Name = "Спорт Плюс",       CurrentProgram = "Футбол: ЦСКА — Спартак",  Progress = 0.45, Number = 102, IsLive = true,  IsHd = true  },
        new() { Abbrev = "24", TileColor = Color.FromArgb("#1450B4"), Name = "Новости 24",       CurrentProgram = "Главные новости часа",    Progress = 0.30, Number = 103, IsLive = true,  IsHd = false },
        new() { Abbrev = "МА", TileColor = Color.FromArgb("#1FA764"), Name = "Матч! Арена",      CurrentProgram = "Хоккей: обзор матчей",    Progress = 0.55, Number = 104, IsLive = true,  IsHd = true  },
        new() { Abbrev = "СЭ", TileColor = Color.FromArgb("#F08C2D"), Name = "Спорт Экстрим",    CurrentProgram = "Сноуборд. Кубок мира",    Progress = 0.78, Number = 105, IsLive = true,  IsHd = true  },
        new() { Abbrev = "БТ", TileColor = Color.FromArgb("#8B3DE8"), Name = "Бокс ТВ",          CurrentProgram = "Лучшие бои года",         Progress = 0.40, Number = 106, IsLive = false, IsHd = false },
        new() { Abbrev = "АС", TileColor = Color.FromArgb("#1450B4"), Name = "Авто Спорт",       CurrentProgram = "Формула: квалификация",   Progress = 0.68, Number = 107, IsLive = true,  IsHd = true  },
    };


    public ChannelsListPage()
	{
		InitializeComponent();
        BindingContext = this;
        ApplyFilter("all");

    }

    private void ApplyFilter(string filterId)
    {
        IEnumerable<ChannelItem> src = filterId switch
        {
            "live" => _allChannels.Where(c => c.IsLive),
            "hd" => _allChannels.Where(c => c.IsHd),
            _ => _allChannels,
        };

        Channels.Clear();
        foreach (var c in src)
            Channels.Add(c);
    }

    private void OnFilterTapped(object? sender, TappedEventArgs e)
    {
        if ((sender as Element)?.BindingContext is not FilterChip tapped)
            return;

        foreach (var chip in Filters)
            chip.IsSelected = chip.Id == tapped.Id;

        ApplyFilter(tapped.Id);
    }

    private void OnFavoriteTapped(object? sender, TappedEventArgs e)
    {
        if ((sender as Element)?.BindingContext is ChannelItem channel)
        {
            channel.IsFavorite = !channel.IsFavorite;
            // TODO: сохранить в избранное (Preferences / API)
        }
    }

    private async void OnChannelTapped(object? sender, TappedEventArgs e)
    {
        if ((sender as Element)?.BindingContext is not ChannelItem channel)
            return;

        // TODO: переход к плееру / странице канала
        await Task.CompletedTask;
    }

    private async void OnBack(object? sender, TappedEventArgs e)
        => await Shell.Current.GoToAsync("..");

    private async void OnSearch(object? sender, TappedEventArgs e)
    {
        // TODO: поиск внутри категории
        await Task.CompletedTask;
    }

}

using BeautyifyMAUI.Models;
using BeautyifyMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BeautyifyMAUI.ViewModels;

public partial class ChannelsListViewModel : ObservableObject, IQueryAttributable
{
    private readonly IDialogService _dialogs;

    public ChannelsListViewModel(IDialogService dialogs)
    {
        _dialogs = dialogs;
        ApplyFilter("all");
    }

    [ObservableProperty]
    private string _categoryTitle = "Каналы";

    public string CategoryId { get; private set; } = "all";

    public ObservableCollection<FilterChip> Filters { get; } =
    [
        new() { Id = "all",  Title = "Все 32", IsSelected = true },
        new() { Id = "live", Title = "Эфир сейчас" },
        new() { Id = "hd",   Title = "HD" },
    ];

    public ObservableCollection<ChannelItem> Channels { get; } = new();

    // Полный список; позже наполняется из API по CategoryId.
    private readonly List<ChannelItem> _allChannels =
    [
        new() { Abbrev = "ПО", TileColor = Color.FromArgb("#1B66E5"), Name = "Первый Областной", CurrentProgram = "Утро в регионе",         Progress = 0.62, Number = 101, IsLive = true,  IsHd = true  },
        new() { Abbrev = "СП", TileColor = Color.FromArgb("#E5342B"), Name = "Спорт Плюс",       CurrentProgram = "Футбол: ЦСКА — Спартак", Progress = 0.45, Number = 102, IsLive = true,  IsHd = true  },
        new() { Abbrev = "24", TileColor = Color.FromArgb("#1450B4"), Name = "Новости 24",       CurrentProgram = "Главные новости часа",   Progress = 0.30, Number = 103, IsLive = true,  IsHd = false },
        new() { Abbrev = "МА", TileColor = Color.FromArgb("#1FA764"), Name = "Матч! Арена",      CurrentProgram = "Хоккей: обзор матчей",   Progress = 0.55, Number = 104, IsLive = true,  IsHd = true  },
        new() { Abbrev = "СЭ", TileColor = Color.FromArgb("#F08C2D"), Name = "Спорт Экстрим",    CurrentProgram = "Сноуборд. Кубок мира",   Progress = 0.78, Number = 105, IsLive = true,  IsHd = true  },
        new() { Abbrev = "БТ", TileColor = Color.FromArgb("#8B3DE8"), Name = "Бокс ТВ",          CurrentProgram = "Лучшие бои года",        Progress = 0.40, Number = 106, IsLive = false, IsHd = false },
        new() { Abbrev = "АС", TileColor = Color.FromArgb("#1450B4"), Name = "Авто Спорт",       CurrentProgram = "Формула: квалификация",  Progress = 0.68, Number = 107, IsLive = true,  IsHd = true  },
    ];

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("category", out var id))
            CategoryId = Uri.UnescapeDataString(id.ToString() ?? "all");

        if (query.TryGetValue("title", out var title))
            CategoryTitle = Uri.UnescapeDataString(title.ToString() ?? "Каналы");

        // TODO: загрузить каналы категории CategoryId из API

        Filters[0].Title = $"Все {_allChannels.Count}";
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

    [RelayCommand]
    private void SelectFilter(FilterChip tapped)
    {
        foreach (var chip in Filters)
            chip.IsSelected = chip.Id == tapped.Id;

        ApplyFilter(tapped.Id);
    }

    [RelayCommand]
    private async Task ToggleFavoriteAsync(ChannelItem channel)
    {
        channel.IsFavorite = !channel.IsFavorite;
        // TODO: сохранить (Preferences / API)

        await _dialogs.ToastAsync(channel.IsFavorite
            ? $"«{channel.Name}» добавлен в избранное"
            : $"«{channel.Name}» убран из избранного");
    }

    [RelayCommand]
    private Task OpenChannelAsync(ChannelItem channel)
    {
        // TODO: переход к плееру
        return Task.CompletedTask;
    }

    [RelayCommand]
    private Task BackAsync() => Shell.Current.GoToAsync("..");

    [RelayCommand]
    private Task SearchAsync()
    {
        // TODO: поиск внутри категории
        return Task.CompletedTask;
    }
}


using BeautyifyMAUI.Controls;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;

namespace BeautyifyMAUI.Services;

public class DialogService : IDialogService
{
    public Task AlertAsync(string title, string message, AlertKind kind = AlertKind.Info)
        => MainThread.InvokeOnMainThreadAsync(() =>
        {
            var page = Shell.Current?.CurrentPage ?? Application.Current?.MainPage;
            return page is null
                ? Task.CompletedTask
                : page.ShowPopupAsync(new BrandAlertPopup(title, message, kind));
        });

    public Task ToastAsync(string message)
        => MainThread.InvokeOnMainThreadAsync(() =>
            Toast.Make(message, ToastDuration.Short, 14).Show());
}

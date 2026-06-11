
using BeautyifyMAUI.Controls;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;

namespace BeautyifyMAUI.Services;

public class DialogService : IDialogService
{
    public Task AlertAsync(string title, string message, AlertKind kind = AlertKind.Info)
     => MainThread.InvokeOnMainThreadAsync(() =>
     {
         var page = Shell.Current?.CurrentPage ?? Application.Current?.Windows[0].Page;
         if (page is null)
             return Task.CompletedTask;

         return page.ShowPopupAsync(new BrandAlertPopup(title, message, kind),
             new PopupOptions
             {
                 // Отключаем дефолтный белый контейнер Popup v2 —
                 // форму, фон и тень рисует наш собственный Border.
                 Shape = null,
                 Shadow = null,
                 CanBeDismissedByTappingOutsideOfPopup = true,
                 PageOverlayColor = Color.FromArgb("#6615191E"),
             });
     });

    public Task ToastAsync(string message)
        => MainThread.InvokeOnMainThreadAsync(() =>
            Toast.Make(message, ToastDuration.Short, 14).Show());

}

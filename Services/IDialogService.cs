
using BeautyifyMAUI.Controls;

namespace BeautyifyMAUI.Services;

public interface IDialogService
{
    Task AlertAsync(string title, string message, AlertKind kind = AlertKind.Info);
    Task ToastAsync(string message);
}

using BeautyifyMAUI.Controls;
using BeautyifyMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BeautyifyMAUI.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IDialogService _dialogs;

    public LoginViewModel(IDialogService dialogs) => _dialogs = dialogs;

    [ObservableProperty]
    private string _contract = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private bool _remember = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EyeGlyph))]
    private bool _isPasswordHidden = true;

    public string EyeGlyph => IsPasswordHidden ? "\ue8f5" : "\ue8f4"; // visibility_off : visibility

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    public bool IsNotBusy => !IsBusy;

    [RelayCommand]
    private void TogglePassword() => IsPasswordHidden = !IsPasswordHidden;

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Contract) || string.IsNullOrWhiteSpace(Password))
        {
            await _dialogs.AlertAsync("Не хватает данных",
                "Укажите номер договора и пароль, чтобы войти в кабинет.",
                AlertKind.Error);
            return;
        }

        try
        {
            IsBusy = true;

            // TODO: вызов API авторизации
            await Task.Delay(600); // имитация запроса

            await Shell.Current.GoToAsync("//channels");
        }
        catch (Exception)
        {
            await _dialogs.AlertAsync("Ошибка входа",
                "Не удалось связаться с сервером. Проверьте подключение и попробуйте ещё раз.",
                AlertKind.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private Task ForgotPasswordAsync()
        => _dialogs.AlertAsync("Восстановление пароля",
            "Позвоните в абонентский отдел или обратитесь в личный кабинет на сайте — мы поможем восстановить доступ.");

    [RelayCommand]
    private Task ConnectAsync()
        => _dialogs.AlertAsync("Подключение",
            "Оставьте заявку на сайте Инфо-Лан или позвоните нам — подключим в ближайшее время.");
}

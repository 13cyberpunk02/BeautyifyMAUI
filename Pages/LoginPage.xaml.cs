namespace BeautyifyMAUI.Pages;

public partial class LoginPage : ContentPage
{
    private CancellationTokenSource? _blobAnimCts;

    public LoginPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _blobAnimCts = new CancellationTokenSource();
        // три эллипса плывут с разной скоростью и амплитудой
#if ANDROID
        _ = FloatBlob(Blob1, 80, -90, 24, 18, 5200, _blobAnimCts.Token);
        _ = FloatBlob(Blob2, -70, 60, -20, -26, 6400, _blobAnimCts.Token);
        _ = FloatBlob(Blob3, -50, -60, 16, 22, 4300, _blobAnimCts.Token);
#endif
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _blobAnimCts?.Cancel();
        _blobAnimCts = null;
    }

    /// <summary>
    /// Бесконечное мягкое "плавание" эллипса вокруг базовой точки.
    /// </summary>
    private static async Task FloatBlob(VisualElement blob,
        double baseX, double baseY, double dx, double dy,
        uint duration, CancellationToken ct)
    {
        try
        {
            while (!ct.IsCancellationRequested)
            {
                await blob.TranslateToAsync(baseX + dx, baseY + dy, duration, Easing.SinInOut);
                if (ct.IsCancellationRequested) break;
                await blob.TranslateToAsync(baseX, baseY, duration, Easing.SinInOut);
            }
        }
        catch (Exception)
        {
            // страница могла быть выгружена — просто выходим
        }
    }

    private void OnTogglePassword(object? sender, TappedEventArgs e)
    {
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        // visibility_off : visibility
        EyeIcon.Text = PasswordEntry.IsPassword ? "\ue8f5" : "\ue8f4";
    }

    private async void OnLoginClicked(object? sender, EventArgs e)
    {
        var contract = ContractEntry.Text?.Trim();
        var password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(contract) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlertAsync("Вход", "Укажите номер договора и пароль.", "Ок");
            return;
        }
        if(contract.Equals("000000") && password.Equals("111111"))
        {
            await Shell.Current.GoToAsync("//main");
        }
        // TODO: вызов API авторизации
    }

    private async void OnForgotPassword(object? sender, TappedEventArgs e)
    {
        // TODO: переход на восстановление пароля
        await Task.CompletedTask;
    }

    private async void OnConnect(object? sender, TappedEventArgs e)
    {
        // TODO: переход на форму подключения
        await Task.CompletedTask;
    }

}
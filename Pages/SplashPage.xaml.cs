namespace BeautyifyMAUI.Pages;

public partial class SplashPage : ContentPage
{
	public SplashPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // лёгкое движение фоновых эллипсов параллельно с логотипом
        _ = SplashBlob1.TranslateToAsync(70, -80, 2600, Easing.SinInOut);
        _ = SplashBlob2.TranslateToAsync(-50, 50, 2600, Easing.SinInOut);

        // 1. появление: масштаб + прозрачность
        await Task.WhenAll(
            Logo.FadeToAsync(1, 350, Easing.CubicOut),
            Logo.ScaleToAsync(1, 350, Easing.CubicOut));

        // 2. поворот на 360°
        await Logo.RotateToAsync(360, 900, Easing.CubicInOut);
        Logo.Rotation = 0; // сброс, чтобы дальнейшие анимации шли от нуля

        // 3. прыжок: вверх быстро, вниз с отскоком
        await Logo.TranslateToAsync(0, -60, 260, Easing.CubicOut);
        await Logo.TranslateToAsync(0, 0, 600, Easing.BounceOut);

        // 4. короткая пауза в центре и переход на авторизацию
        await Task.Delay(450);
        await Shell.Current.GoToAsync("//login");
        // Если без Shell: Application.Current!.MainPage = new NavigationPage(new LoginPage());
    }

}
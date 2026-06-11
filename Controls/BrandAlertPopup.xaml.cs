using CommunityToolkit.Maui.Views;
#if ANDROID
using static Android.Webkit.ConsoleMessage;
#endif
namespace BeautyifyMAUI.Controls;


public enum AlertKind { Info, Success, Error }

public partial class BrandAlertPopup : Popup
{
    public BrandAlertPopup(string title, string message,
                         AlertKind kind = AlertKind.Info,
                         string buttonText = "Понятно")
    {
        InitializeComponent();

        TitleLabel.Text = title;
        MessageLabel.Text = message;
        OkButton.Text = buttonText;

        var (glyph, fg, bg) = kind switch
        {
            AlertKind.Success => ("\uf0be", "#1FA764", "#E3F6EC"), // check_circle
            AlertKind.Error => ("\uf8b6", "#E5342B", "#FCE7E6"), // error
            _ => ("\ue88e", "#1B66E5", "#E4EDFC"), // info
        };

        IconLabel.Text = glyph;
        IconLabel.TextColor = Color.FromArgb(fg);
        IconCircle.BackgroundColor = Color.FromArgb(bg);
    }

    private async void OnOkClicked(object? sender, EventArgs e)
        => await CloseAsync();
}
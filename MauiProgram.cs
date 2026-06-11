using BeautyifyMAUI.Pages;
using Microsoft.Extensions.Logging;

namespace BeautyifyMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Onest-Medium.ttf", "OnestMedium");
                    fonts.AddFont("Onest-Regular.ttf", "Onest");
                    fonts.AddFont("Onest-Bold.ttf", "OnestBold");                    
                    fonts.AddFont("MaterialSymbolsRounded-Filled.ttf", "MaterialSymbols");
                });

            builder.Services.AddTransient<LoginPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

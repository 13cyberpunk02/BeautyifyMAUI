using BeautyifyMAUI.Pages;
using BeautyifyMAUI.Services;
using BeautyifyMAUI.ViewModels;
using CommunityToolkit.Maui;
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
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Onest-Medium.ttf", "OnestMedium");
                    fonts.AddFont("Onest-Regular.ttf", "Onest");
                    fonts.AddFont("Onest-Bold.ttf", "OnestBold");                    
                    fonts.AddFont("MaterialSymbolsRounded-Filled.ttf", "MaterialSymbols");
                });

            builder.Services.AddSingleton<IDialogService, DialogService>();


            // ===== ViewModels =====
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<CategoryViewModel>();
            builder.Services.AddTransient<ChannelsListViewModel>();

            // ===== Pages (Shell берёт их из DI и сам внедряет VM в конструктор) =====
            builder.Services.AddTransient<SplashPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<ChannelsListPage>();
            builder.Services.AddTransient<CategoryPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

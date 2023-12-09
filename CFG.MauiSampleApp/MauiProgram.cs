using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CFG.MauiSampleApp.Services;
using CFG.MauiSampleApp.Views;
using CFG.MauiSampleApp.ViewModels;

namespace CFG.MauiSampleApp
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
                    fonts.AddFont("fa_solid.ttf", "FontAwesome");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif


            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<ICountryService, CountryService>();

            builder.Services.AddSingleton<RegistrationViewModel>();

            builder.Services.AddSingleton<MainView>();
            builder.Services.AddSingleton<RegistrationView>();            
            builder.Services.AddSingleton<BasicPickerNoMvvMView>();
            return builder.Build();
        }
    }
}

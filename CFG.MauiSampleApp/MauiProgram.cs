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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif


            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<ICountryService, CountryService>();

            builder.Services.AddSingleton<RegistrationViewModel>();
            builder.Services.AddSingleton<RegistrationView>();
            return builder.Build();
        }
    }
}

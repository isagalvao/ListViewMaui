using Microsoft.Extensions.Logging;
using epj.RouteGenerator;
using ListViewMaui.ViewModel;
using ListViewMaui.View;
using ListViewMaui.Models;
using CommunityToolkit.Maui;
using ListViewMaui.Services;
using ListViewMaui.Services.Business;

namespace ListViewMaui
{
    [AutoRoutes("Page")]
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .RegisterServices()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<User>();
            builder.Services.AddSingleton<Navigate>();
            builder.Services.AddSingleton<ListUserRepository>();
            builder.Services.AddSingleton<IShellNavigationService, ShellNavigationService>();

            builder.Services.AddTransient<MainPage, MainPageViewModel>();
            builder.Services.AddTransient<DetailsPage, DetailsPageViewModel>();
            builder.Services.AddTransient<UserRegistrationPage, UserRegistrationPageViewModel>();

            return builder;
        }
    }
}

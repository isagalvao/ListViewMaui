using Microsoft.Extensions.Logging;
using epj.RouteGenerator;
using ListViewMaui.ViewModel;
using ListViewMaui.View;
using ListViewMaui.Services.Business;
using ListViewMaui.Models;
using CommunityToolkit.Maui;

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
            builder.Services.AddSingleton<ListUserBusiness>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<User>();
            builder.Services.AddSingleton<UserRegistrationPageViewModel>();

            // Registrar a página
            builder.Services.AddTransient<UserListPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<UserRegistrationPage>();

            return builder;
        }
    }
}

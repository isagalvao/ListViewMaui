using ListViewMaui.View;

namespace ListViewMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(Routes.DetailsPage, typeof(DetailsPage));
            Routing.RegisterRoute(Routes.UserRegistrationPage, typeof(UserRegistrationPage));
        }
    }
}

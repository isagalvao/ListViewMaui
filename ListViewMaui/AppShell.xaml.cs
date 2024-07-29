using ListViewMaui.View;

namespace ListViewMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(Routes.UserListPage, typeof(UserListPage));
            Routing.RegisterRoute(Routes.UserRegistrationPage, typeof(UserRegistrationPage));
        }
    }
}

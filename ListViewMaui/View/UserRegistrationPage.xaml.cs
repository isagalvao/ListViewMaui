using ListViewMaui.ViewModel;

namespace ListViewMaui.View;

public partial class UserRegistrationPage : ContentPage
{
    public UserRegistrationPage(UserRegistrationPageViewModel userRegistrationPageViewModel)
    {
        InitializeComponent();
        BindingContext = userRegistrationPageViewModel;
    }
}
using ListViewMaui.ViewModel;

namespace ListViewMaui.View;

[QueryProperty(nameof(UserId), "Id")]
public partial class DetailsPage : ContentPage
{
    private DetailsPageViewModel ViewModel;

    public DetailsPage(DetailsPageViewModel detailsPageViewModel)
    {
        InitializeComponent();
        ViewModel = detailsPageViewModel;
        BindingContext = ViewModel;
    }

    public string UserId
    {
        set
        {
            ViewModel.LoadUser(int.Parse(value));
        }
    }
}

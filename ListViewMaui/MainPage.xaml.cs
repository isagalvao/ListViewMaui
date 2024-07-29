using ListViewMaui.Services.Business;
using ListViewMaui.ViewModel;

namespace ListViewMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            BindingContext = mainPageViewModel;
            InitializeComponent();
        }
    }

}

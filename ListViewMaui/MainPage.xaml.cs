using ListViewMaui.Models;

using ListViewMaui.ViewModel;

namespace ListViewMaui
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel mainPageViewModel;

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            
            this.mainPageViewModel = mainPageViewModel;
            
            BindingContext = mainPageViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            mainPageViewModel.LoadUsers();
            mainPageViewModel.CheckIfListIsEmpty();

        }
    }

}

namespace ListViewMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnResume()
        {
            base.OnResume();

            Shell.Current.GoToAsync("///MainPage");
        }
    }
}

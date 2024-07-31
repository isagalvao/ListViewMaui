using ListViewMaui.Models;

namespace ListViewMaui.Services
{
    public class Navigate : INavigate
    {
        private readonly IShellNavigationService _shellNavigationService;
        public Navigate(IShellNavigationService shellNavigationService)
        {
            _shellNavigationService = shellNavigationService;
        }

        public async Task DetailsPage(User DetailsUser)
        {
            var route = $"DetailsPage?DetailsUser={DetailsUser}";

            await _shellNavigationService.GoToAsync(route);

        }

        public async Task MainPage()
        {
            await _shellNavigationService.GoToAsync("///MainPage");

        }

        public async Task UserRegistrationPage()
        {
            await _shellNavigationService.GoToAsync("///UserRegistrationPage");

        }
    }
}

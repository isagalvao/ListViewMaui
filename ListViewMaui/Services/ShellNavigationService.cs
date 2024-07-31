namespace ListViewMaui.Services
{
    public class ShellNavigationService : IShellNavigationService
    {
        public async Task GoToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }

        public async Task GoToAsyncWithParams(string route, IDictionary<string, object> parameters)
        {
            await Shell.Current.GoToAsync(route, parameters);
        }
    }
}

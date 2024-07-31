using ListViewMaui.Models;

namespace ListViewMaui.Services
{
    public interface INavigate
    {
        Task DetailsPage(User DetailsUser);
        Task MainPage();
    }
}

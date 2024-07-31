using ListViewMaui.Models;

namespace ListViewMaui.Services.Business
{
    internal interface IListUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        List<User> GetAll();
        User GetById(int id);
        Task<bool> ValidateUserAsync(User user);
    }
}

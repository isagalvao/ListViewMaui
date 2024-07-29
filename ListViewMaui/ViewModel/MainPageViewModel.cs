using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ListViewMaui.Models;
using ListViewMaui.Services.Business;
using System.Collections.ObjectModel;

namespace ListViewMaui.ViewModel
{
    public partial class MainPageViewModel : ViewModelBase
    {
        private readonly ListUserBusiness _userBusiness;

        private ObservableCollection<User> _userList;
        public ObservableCollection<User> UserList
        {
            get => _userList;
            set => SetProperty(ref _userList, value);
        }

        [ObservableProperty]
        private bool isListEmpty;

        public MainPageViewModel(ListUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
            UserList = new ObservableCollection<User>(_userBusiness.Users);
            _userBusiness.Users.CollectionChanged += (s, e) => LoadUsers();

            LoadUsers();
        }

        private void LoadUsers()
        {
            UserList.Clear(); 

            foreach (var user in _userBusiness.Users)
            {
                UserList.Add(user);
            }

            CheckIfListIsEmpty();
        }

        [RelayCommand]
        public async Task Add()
        {
            await Shell.Current.GoToAsync("//UserRegistrationPage");
        }

        private void CheckIfListIsEmpty()
        {
            IsListEmpty = !UserList.Any();
        }
    }
}

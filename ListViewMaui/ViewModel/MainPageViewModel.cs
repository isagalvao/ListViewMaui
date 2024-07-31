using CommunityToolkit.Mvvm.Input;
using ListViewMaui.Models;
using ListViewMaui.Services;
using ListViewMaui.Services.Business;
using ListViewMaui.View;
using System.Collections.ObjectModel;

namespace ListViewMaui.ViewModel
{
    public partial class MainPageViewModel : ViewModelBase
    {
        private readonly ListUserRepository _listUserRepository;
        private readonly Navigate _navigate;
        public ObservableCollection<User> UserList { get; set; }
        public bool IsListEmpty { get; set; }

        private User _selectedItem;
        public User SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel(ListUserRepository listUserRepository, Navigate navigate)
        {
            _navigate = navigate;
            _listUserRepository = listUserRepository;

            UserList = new ObservableCollection<User>();

            LoadUsers();
            CheckIfListIsEmpty();
        }

        public void LoadUsers()
        {
            SelectedItem = null;
            UserList.Clear();

            foreach (var user in _listUserRepository.GetAll())
            {
                UserList.Add(user);
            }

            OnPropertyChanged(nameof(UserList));
            CheckIfListIsEmpty();
        }

        [RelayCommand]
        public async Task Add()
        {
            await _navigate.UserRegistrationPage();
        }

        [RelayCommand]
        public async Task EditUser(User user)
        {
            if (user != null)
            {
                await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?Id={user.Id}");
            }
        }

        public void CheckIfListIsEmpty()
        {
            IsListEmpty = UserList.Count <= 0;
            OnPropertyChanged(nameof(IsListEmpty));
        }
    }
}

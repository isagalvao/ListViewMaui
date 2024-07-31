using CommunityToolkit.Mvvm.Input;
using ListViewMaui.Models;
using ListViewMaui.Services;
using ListViewMaui.Services.Business;

namespace ListViewMaui.ViewModel
{
    public partial class DetailsPageViewModel : ViewModelBase
    {
        private readonly ListUserRepository _listUserRepository;
        private readonly Navigate _navigate;

        private User _user;
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public DetailsPageViewModel(ListUserRepository listUserRepository, Navigate navigate)
        {
            _navigate = navigate;
            _listUserRepository = listUserRepository;

            User = new User();
        }

        [RelayCommand]
        public async Task Update()
        {

            if (await _listUserRepository.ValidateUserAsync(User))
            {

                _listUserRepository.UpdateUser(User);
                await _navigate.MainPage();
            }
        }

        [RelayCommand]
        public async Task Delete()
        {
            bool confirm = await App.Current.MainPage.DisplayAlert("Deletar", "Deseja deletar o Contato?", "Sim", "Não");

            if (confirm)
            {
                _listUserRepository.DeleteUser(User.Id);
                await _navigate.MainPage();
            }

        }

        [RelayCommand]
        public async Task Back()
        {
            await _navigate.MainPage();
        }

        public async void LoadUser(int Id)
        {
            User = _listUserRepository.GetById(Id).Clone();

            OnPropertyChanged(nameof(User));
        }
    }
}

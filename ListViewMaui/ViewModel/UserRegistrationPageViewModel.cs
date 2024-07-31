using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ListViewMaui.Models;
using ListViewMaui.Services;
using ListViewMaui.Services.Business;

namespace ListViewMaui.ViewModel
{
    public partial class UserRegistrationPageViewModel : ViewModelBase
    {
        private readonly ListUserRepository _listUserRepository;
        private readonly Navigate _navigate;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _phone;

        [ObservableProperty]
        private string _cpf;

        public UserRegistrationPageViewModel(ListUserRepository listUserRepository, Navigate navigate)
        {
            _navigate = navigate;
            _listUserRepository = listUserRepository;
        }

        [RelayCommand]
        public async Task Save()
        {
            var newUser = new User
            {
                Name = Name,
                Phone = Phone,
                CPF = Cpf
            };

            if (await _listUserRepository.ValidateUserAsync(newUser))
            {
                _listUserRepository.AddUser(newUser);

                await App.Current.MainPage.DisplayAlert("Sucesso", "Dados salvos com sucesso!", "OK");

                Name = string.Empty;
                Phone = string.Empty;
                Cpf = string.Empty;

                await _navigate.MainPage();
            }
        }

        [RelayCommand]
        public async Task Cancel()
        {
            bool confirm = await App.Current.MainPage.DisplayAlert("Cancelar", "Deseja cancelar o cadastro?", "Sim", "Não");
            if (confirm)
            {
                Name = string.Empty;
                Phone = string.Empty;
                Cpf = string.Empty;

                await _navigate.MainPage();
            }
        }
    }
}

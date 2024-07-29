using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ListViewMaui;
using ListViewMaui.Models;
using ListViewMaui.Services.Business;
using ListViewMaui.ViewModel;

namespace ListViewMaui.ViewModel
{
    public partial class UserRegistrationPageViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string phone;

        [ObservableProperty]
        private string cpf;

        public UserRegistrationPageViewModel()
        {
        }

        [RelayCommand]
        public async Task Save()
        {
            var user = new User { Name = Name, Phone = Phone, CPF = Cpf };

            if (!await ListUserBusiness.Instance.ValidateUserAsync(user))
            {
                return;
            }

            ListUserBusiness.Instance.AddUser(user);

            await App.Current.MainPage.DisplayAlert("Sucesso", "Dados salvos com sucesso!", "OK");

            Name = string.Empty;
            Phone = string.Empty;
            Cpf = string.Empty;

            await Shell.Current.GoToAsync("//MainPage");
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

                await Shell.Current.GoToAsync("//MainPage");
            }
        }
    }
}

using ListViewMaui.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ListViewMaui.Services.Business
{
    public partial class ListUserBusiness
    {
        private static ListUserBusiness _instance;
        public static ListUserBusiness Instance => _instance ??= new ListUserBusiness();

        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        public ListUserBusiness()
        {
            Users.CollectionChanged += (s, e) => OnUsersChanged(e);
        }

        public event EventHandler<NotifyCollectionChangedEventArgs> UsersChanged;

        private void OnUsersChanged(NotifyCollectionChangedEventArgs e)
        {
            UsersChanged?.Invoke(this, e);
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                Users.Add(user);
            }
        }

        public async Task<bool> ValidateUserAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Nome é obrigatório.", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.Phone) || !IsValidPhoneNumber(user.Phone))
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Número de telefone inválido.", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.CPF) || !IsValidCPF(user.CPF))
            {
                await App.Current.MainPage.DisplayAlert("Erro", "CPF inválido.", "OK");
                return false;
            }

            return true;
        }

        private bool IsValidPhoneNumber(string number)
        {
            var regex = new Regex(@"^\(\d{2}\) \d{4,5}-\d{4}$");
            return regex.IsMatch(number);
        }

        private bool IsValidCPF(string cpf)
        {
            return cpf.Length == 14 && cpf[3] == '.' && cpf[7] == '.' && cpf[11] == '-';
        }
    }
}

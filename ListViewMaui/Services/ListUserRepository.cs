using ListViewMaui.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;

namespace ListViewMaui.Services.Business
{
    public partial class ListUserRepository : IListUserRepository
    {
        private static ListUserRepository _instance;
        public static ListUserRepository Instance => _instance ??= new ListUserRepository();

        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        public ListUserRepository()
        {

        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                user.Id = Users.Count + 1;
                Users.Add(user);
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return Users.ToList();
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }

        public User GetById(int id)
        {
            return Users.Where(x => x.Id == id).First();
        }

        public void DeleteUser(int id)
        {
            var existingUser = Users.FirstOrDefault(u => u.Id == id);

            if (existingUser != null)
            {
                Users.Remove(existingUser);
            }
        }

        public void UpdateUser(User user)
        {
            var index = Users.IndexOf(Users.FirstOrDefault(u => u.Id == user.Id));
            if (index >= 0)
            {
                Users[index] = user;
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

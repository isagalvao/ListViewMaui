using ListViewMaui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui.Services.Business
{
    internal interface IListUserBusiness
    {
        Task <ObservableCollection<User>> GetList();
        void AddUser(User user);
        Task<bool> ValidateUserAsync(User user);
    }
}

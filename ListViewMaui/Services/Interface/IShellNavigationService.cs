using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui.Services
{
    public interface IShellNavigationService
    {
        Task GoToAsync(string route);
        Task GoToAsyncWithParams(string route, IDictionary<string, object> parameters);
    }
}

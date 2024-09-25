using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoInternetApp.ViewModels
{
    public class MainViewModel
    {
        public ICommand btnCheckInternetCommand => new Command(() =>
        {
            string message = string.Empty;
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType == NetworkAccess.Internet)
            {
                message = "Device has internet access";
            }
            else
            {
                message = "Device has no internet access";
            }
            //handles message here
        });

    }
}

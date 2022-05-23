using Kursach.Infrastructure.Commands;
using Kursach.Models;
using Kursach.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Kursach.ViewModels
{
    internal class StartPageViewModel : ViewModel
    {
        private Visibility _AdmPageVisibilty;
        public Visibility AdmPageVisibilty
        {
            get => _AdmPageVisibilty;
            set => Set(ref _AdmPageVisibilty, value);
        }
        public StartPageViewModel()
        {
            if (CurrentUser.getInstance().IsAdmin == true)
            {
                AdmPageVisibilty = Visibility.Visible;
            }
            else AdmPageVisibilty = Visibility.Hidden;

        }
    }
}

using Kursach.Infrastructure.Commands;
using Kursach.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kursach.ViewModels
{
    internal class StartPageViewModel : ViewModel
    {
        #region Комманды

        #region Закрыть приложение
        public ICommand CloseApplicationCommand { get; }

        public bool CanCloseApplicationCommandExecute(object p) => true;
        public void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #endregion

        public StartPageViewModel()
        {
            #region Комманды
            CloseApplicationCommand = new RelayCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            #endregion
        }
    }
}

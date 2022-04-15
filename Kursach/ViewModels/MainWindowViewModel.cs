using Kursach.Infrastructure.Commands;
using Kursach.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kursach.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        public MainWindowViewModel()
        {
            #region Комманды
            OpenStartPage = new RelayCommand(OnOpenStartPageExecuted, CanOpenStartPageExecute);
            #endregion
        }

        #region Заголовок окна
        private string _Title = "Login Window";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region Комманды

        #region Открытие страницы главного меню
        public ICommand OpenStartPage;

        public void OnOpenStartPageExecuted(object p)
        {
           
        }
        public bool CanOpenStartPageExecute(object p) => true;
        #endregion

        #endregion
    }
}

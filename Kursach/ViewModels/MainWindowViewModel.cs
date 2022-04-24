using Kursach.Infrastructure.Commands;
using Kursach.Models.Base;
using Kursach.Models;
using Kursach.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Kursach.Infrastructure.Commands.Base;


namespace Kursach.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        public string login;
        public string password;
        public MainWindowViewModel()
        {
            #region Комманды
            AuthButtonClickCommand = new RelayCommand(OnAuthButtonClickCommandExecuted, CanAuthButtonClickCommandExecute);
            #endregion
        }

        private string _Title = "Login Page";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }


        #region Команды
        public ICommand? AuthButtonClickCommand { get; }
        private void OnAuthButtonClickCommandExecuted(object p)
        {
            Login AuthUser = null;
            using (SAYKOV_PDDContext db = new SAYKOV_PDDContext())
            {
                AuthUser = db.Logins.Where(b => b.LoginName == login && b.Passwords== password).FirstOrDefault();
            }
            if (AuthUser != null)
                MessageBox.Show("All is good!");
            else
                MessageBox.Show("Проверьте введённые данные");
        }

        private bool CanAuthButtonClickCommandExecute(object p) => true;
        #endregion
    }
}
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
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Controls;

namespace Kursach.ViewModels
{
    internal class MainWindowViewModel : ViewModel, INotifyPropertyChanged
    {
        private SolidColorBrush _bb;
        public SolidColorBrush bb
        {
            get=> _bb;
            set => Set(ref _bb, value);
        }
        private Page _StartPage;
        public Page StartPage
        {
            get => _StartPage;
            set => Set(ref _StartPage, value);
        }
        
        private MainWindow _mWindow;
        public MainWindow mWindow
        {
            get { return _mWindow; }
            set
            {
                _mWindow = value;
                OnPropertyChanged("mWindow");
            }

        }
           private string _Login;
        private string _Password;
        private string? _Num;
        public string Num
        {
            get => _Num;
            set => Set(ref _Num, value);
        }
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);

        }
        public MainWindowViewModel()
        {
            var converter = new System.Windows.Media.BrushConverter();
            bb = (SolidColorBrush)(Brush)converter.ConvertFromString("#673AB7");
            #region Команды
            RegUserCommand = new RelayCommand(OnRegUserCommandExecuted, CanRegUserCommandExecute);
            AuthButtonClickCommand = new RelayCommand(OnAuthButtonClickCommandExecuted, CanAuthButtonClickCommandExecute);
            RegisterCommand =new RelayCommand(OnRegisterCommandExecuted, CanRegisterCommandExecute);
            AuthCommand = new RelayCommand(OnAuthCommandExecuted, CanAuthButtonClickCommandExecute);
            #endregion
        }

        private string _Title = "Login Page";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }


        #region Команды
        public ICommand RegisterCommand { get; set; }
        public void OnRegisterCommandExecuted(object p)
        {
            
            mWindow = (MainWindow)p;
            mWindow.AuthForm.Visibility = Visibility.Hidden;
            mWindow.RegistForm.Visibility = Visibility.Visible;
        }
        public bool CanRegisterCommandExecute(object p) => true;

        public ICommand AuthCommand { get; set; }
        public void OnAuthCommandExecuted(object p)
        {
            mWindow.AuthForm.Visibility = Visibility.Visible;
            mWindow.RegistForm.Visibility = Visibility.Hidden;
        }
        public bool CanAuthCommandExecute(object p) => true;
        public ICommand? AuthButtonClickCommand { get; }
        private void OnAuthButtonClickCommandExecuted(object p)
        {
            mWindow = (MainWindow)p;
            try
            {
                if (DataWorker.GetUser(Login, Password))
                {
                    StartPage = new StartPage();
                    StartPage.DataContext = new StartPageViewModel();
                    mWindow.MainGrid.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Проверьте введённые данные");
                    bb = Brushes.Red;
                }
            }
            catch(Exception er)
            {
                bb = Brushes.Red;
            }
            
           
        }

        private bool CanAuthButtonClickCommandExecute(object p) => true;

        public ICommand? RegUserCommand { get; }
        private void OnRegUserCommandExecuted(object p)
        {
               if(DataWorker.AddUser(Login,Password,Num))
            {
                MessageBox.Show("Пользователь успешно добавлен.");
                    mWindow.RegistForm.Visibility = Visibility.Hidden;
                mWindow.AuthForm.Visibility = Visibility.Visible;
            }
               else
            {
                bb = Brushes.Red;
            }
        }

        private bool CanRegUserCommandExecute(object p) => true;
        #endregion
    }
}
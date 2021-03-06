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
using Kursach.Views.Windows;
using System.Text.RegularExpressions;
using System.Windows.Navigation;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;

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
        private string _Password;
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);

        }
        private string _UserName;
        public string UserName
        {
            get => _UserName;
            set => Set(ref _UserName, value);

        }
        private string _UserSurname;
        public string UserSurname
        {
            get => _UserSurname;
            set => Set(ref _UserSurname, value);

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
            messageQueue = new SnackbarMessageQueue();
            string message;
            mWindow = (MainWindow)p;
            try
            {
                if (DataWorker.GetUser(Login, Password))
                {
                    if(CurrentUser.getInstance().IsAdmin == false)
                    {

                    StartPage = new StartPage();
                    StartPage.DataContext = new StartPageViewModel();
                    }
                    if(CurrentUser.getInstance().IsAdmin == true)
                    {
                        StartPage = new AdminStartPage();
                        StartPage.DataContext = new AdminPageViewModel();
                    }

                    mWindow.MainGrid.Visibility = Visibility.Hidden;
                }
                else
                {
                    message = "Неправильно введён логин или пароль.";
                    bb = Brushes.Red;
                    Task.Factory.StartNew(() => messageQueue.Enqueue(message));

                }

            }
            catch (Exception er)
            {
                bb = Brushes.Red;
                message = "Проверьте введённые данные.";
                Task.Factory.StartNew(() => messageQueue.Enqueue(message));

            }

        }
          private SnackbarMessageQueue _messageQueue;
        public SnackbarMessageQueue messageQueue
        {
            get => _messageQueue;
            set => Set(ref _messageQueue, value);
        }
        
       
        private bool CanAuthButtonClickCommandExecute(object p) => true;

        public ICommand? RegUserCommand { get; }
        private void OnRegUserCommandExecuted(object p)
        {
            messageQueue = new SnackbarMessageQueue();
            string message;   
               if(DataWorker.AddUser(Login,Password,Num, UserName, UserSurname))
            {
                message = "Пользователь успешно добавлен.";
                    mWindow.RegistForm.Visibility = Visibility.Hidden;
                mWindow.AuthForm.Visibility = Visibility.Visible;
            }
               else
            {
                message = "Ошибка регистрации";
            }
            //the message queue can be called from any thread
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }
     
  
        private bool CanRegUserCommandExecute(object p) => true;
        #endregion
        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
            regex.Replace(" ", "");
            e.Handled = regex.IsMatch(e.Text);
        } 
        public void PasswordValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{6,}");
            regex.Replace(" ", "");
           
        } public void NameValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"([А-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})$");
            regex.Replace(" ", "");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
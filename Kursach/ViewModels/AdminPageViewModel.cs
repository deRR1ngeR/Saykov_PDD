using Kursach.ViewModels.Base;
using Kursach.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Kursach.Models.Base;
using System.Windows.Input;
using System.ComponentModel;
using System;
using Kursach.Infrastructure.Commands;

namespace Kursach.ViewModels

{
    internal class AdminPageViewModel : ViewModel, INotifyPropertyChanged
    {
        MainWindowViewModel MWindowMV;
        readonly SAYKOV_PDDContext db;
        MainWindowViewModel mainMW = new MainWindowViewModel();

        private ObservableCollection<Login> _UsersCollection;
        private Login _SelectedUser;
        public Login SelectedUser
        {
            get { return _SelectedUser; }
            set
            {
                Set(ref _SelectedUser, value);

            }
        }
        public ObservableCollection<Login> UsersCollection
        {
            get { return _UsersCollection; }
            set => Set(ref _UsersCollection, value);
        }
        public AdminPageViewModel(MainWindowViewModel MWindow)
        {
            MWindowMV= MWindow;
            db = new SAYKOV_PDDContext();
            UsersCollection = new ObservableCollection<Login>(db.Logins.ToList());
            DeleteUserCommand = new RelayCommand(OnDeleteUserCommandExecuted, CanDeleteUserCommandExecute);
        }
        public ICommand DeleteUserCommand { get; set; }
        public bool CanDeleteUserCommandExecute(object p) => true;
        public void OnDeleteUserCommandExecuted(object p)
        {
            try
            {

                db.Logins.Remove(SelectedUser);
                db.SaveChanges();
                using (var dbcon = new SAYKOV_PDDContext())
                {
                    UsersCollection = new ObservableCollection<Login>(dbcon.Logins);

                }
            }
            catch(Exception ex)
            {

            }
        }


    }
}

using Kursach.Infrastructure.Commands;
using Kursach.Infrastructure.Commands.Base;
using Kursach.Models;
using Kursach.Models.Base;
using Kursach.ViewModels;
using System.Windows;
using System.Collections.ObjectModel;


namespace Kursach.Infrastructure.Commands
{
    internal class DeletUserCommand: Command
    {
        AdminPageViewModel AdminWM = new AdminPageViewModel();
        public override bool CanExecute(object? parameter) => true;
        public override void Execute(object? parameter)
        {
            var SelectedUser = (Login)parameter;
            if(SelectedUser != null)
            {
                if(SelectedUser.IsAdmin == true)
                {
                    MessageBox.Show("Вы не можете удалить пользователя со статусом \"Админ\". ");
                }
               else if(SelectedUser == CurrentUser.getInstance())
                {
                    MessageBox.Show("Вы не можете удалить свой профиль.");
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить данного пользователя?","Удаление пользователя", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            using (var db = new SAYKOV_PDDContext())
                            {
                               
                                db.Logins.Remove(SelectedUser);
                                db.SaveChanges();
                                
                            }
                            using (var db = new SAYKOV_PDDContext())
                            {
                            AdminWM.UsersCollection = new ObservableCollection<Login>(db.Logins);
                            }
                             break;
                        case MessageBoxResult.No:
                            break;
                        
                    }
                }
            }
        }
    }
}

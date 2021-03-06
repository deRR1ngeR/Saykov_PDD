using Kursach.Models.Base;
using Kursach.Models;
using System.Collections.ObjectModel;
using System.Data.Entity;
using Kursach.ViewModels.Base;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Controls;

namespace Kursach.ViewModels
{
    internal class TrainingPageViewModel: ViewModel, INotifyPropertyChanged
    {
        private Visibility _AdmPageVisibilty;
        public Visibility AdmPageVisibilty
        {
            get => _AdmPageVisibilty;
            set =>Set(ref _AdmPageVisibilty, value);
        }
        private Ticket sTicket;
        public Page ticketPage = new TicketPage();
     readonly SAYKOV_PDDContext db;
     public ObservableCollection<Ticket> Tkts { get; set; }
        private Ticket _SelectedTicket;
        public Ticket SelectedTicket
        {   get
            {
                return _SelectedTicket;
            }
            set
            {
                _SelectedTicket = value;
                OnPropertyChanged("SelectedTicket");
                OpenTicket();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public TrainingPageViewModel()
     {
            if (CurrentUser.getInstance().IsAdmin == true)
            {
                AdmPageVisibilty = Visibility.Visible;
            }
            else AdmPageVisibilty = Visibility.Hidden;
         db = new SAYKOV_PDDContext();
         db.Tickets.Load();
         Tkts = db.Tickets.Local.ToObservableCollection();
     }
        public NavigationWindow win;

        public void OpenTicket()
        {
            win = new NavigationWindow();
            if (SelectedTicket != null)
                sTicket = SelectedTicket;
            if (SelectedTicket == null)
                ticketPage.DataContext = new TicketPageViewModel(sTicket, this);
            else
            ticketPage.DataContext = new TicketPageViewModel(SelectedTicket, this);
            win.Content = ticketPage;
            win.WindowStyle = WindowStyle.None;
            win.Show();
        }
        public void CloseTicket()
        {
            win.Close();
        }
    }
}

using Kursach.ViewModels.Base;
using Kursach.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Kursach.Models.Base;
using System.Linq;
using System.Windows;

namespace Kursach.ViewModels
{
   
    internal class Traffic_RulesViewModel: ViewModel
    {
        private Visibility _AdmPageVisibilty;
        public Visibility AdmPageVisibilty
        {
            get => _AdmPageVisibilty;
            set => Set(ref _AdmPageVisibilty, value);
        }
        readonly SAYKOV_PDDContext db;
        public ObservableCollection<PddInfo> Info { get; set; }
        public Traffic_RulesViewModel()
        {
            db = new SAYKOV_PDDContext();
            
            Info = new ObservableCollection<PddInfo>(db.PddInfos.ToList());
            if (CurrentUser.getInstance().IsAdmin == true)
            {
                AdmPageVisibilty = Visibility.Visible;
            }
            else AdmPageVisibilty = Visibility.Hidden;
        }
        
    }
}

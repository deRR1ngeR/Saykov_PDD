using Kursach.ViewModels.Base;
using Kursach.Models;
using System.Data.Entity;
using System.ComponentModel;

namespace Kursach.ViewModels
{
   
    internal class Traffic_RulesViewModel: ViewModel
    {
        ApplicationContext db;
        public BindingList<PDD_Info> Info { get; set; }
        public Traffic_RulesViewModel()
        {

            db = new ApplicationContext();
            db.PDD_Info.Load();
            Info = db.PDD_Info.Local.ToBindingList();
        }
        
    }
}

using Kursach.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kursach.Models;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Kursach.ViewModels
{
   
    internal class Traffic_RulesViewModel: ViewModel
    {
        ApplicationContext db;
        public BindingList<PDD_Fine> Info { get; set; }
        public Traffic_RulesViewModel()
        {

            db = new ApplicationContext();
            db.PDD_Fine.Load();
            Info = db.PDD_Fine.Local.ToBindingList();
            

           
        }
    }
}

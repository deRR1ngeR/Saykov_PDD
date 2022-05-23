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

namespace Kursach.ViewModels

{
    internal class Forfeit_pageViewModel: ViewModel
    {
        readonly SAYKOV_PDDContext db;
        public ObservableCollection<FineThem> Them { get; set; }
        public ObservableCollection<Fine> Info { get; set; }
        public ArrayList infos { get; set; }


        public Forfeit_pageViewModel()
        {

            db = new SAYKOV_PDDContext();
           
            Them = new ObservableCollection<FineThem>(db.FineThems.ToList());
            Info = new ObservableCollection<Fine> (db.Fines.ToList());
            
            
        }
        
    }
}

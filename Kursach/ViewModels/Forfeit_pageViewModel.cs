using Kursach.ViewModels.Base;
using Kursach.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Kursach.Models.Base;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Kursach.ViewModels

{
    internal class Forfeit_pageViewModel
    {
        readonly SAYKOV_PDDContext db;
        public ObservableCollection<FineThem> Them { get; set; }
        public ObservableCollection<Fine> Info { get; set; }
       public ArrayList infos { get; set; }


        public Forfeit_pageViewModel()
        {

            db = new SAYKOV_PDDContext();
            db.FineThems.Load();
            db.Fines.Load();
            Them = db.FineThems.Local.ToObservableCollection();
            Info= db.Fines.Local.ToObservableCollection();
         //  using (SAYKOV_PDDContext db = new SAYKOV_PDDContext())
         //  {
         //      var fines = db.FineThems.Join(db.Fines,
         //          u => u.FineId,
         //          c => c.FineThemId,
         //          (u, c) => new
         //          {
         //              FineId = c.FineId,
         //              ThemId = c.FineThemId,
         //              FineText = c.FineText,
         //              Cost = c.FineCost,
         //              FineThem = c.FineThem
         //          }
         //          ) ;
         //      foreach(var t in fines)
         //      {
         //        infos.Add(t);
         //      }
         //  }
        }
    }
}

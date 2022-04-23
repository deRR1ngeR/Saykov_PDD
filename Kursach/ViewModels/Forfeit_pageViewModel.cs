using Kursach.ViewModels.Base;
using Kursach.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Kursach.Models.Base;


namespace Kursach.ViewModels

{ 
    internal class Forfeit_pageViewModel
  {
        readonly SAYKOV_PDDContext db;
        public ObservableCollection<FineThem> Fine { get; set; }

        public Forfeit_pageViewModel()
        {

            db = new SAYKOV_PDDContext();
            db.FineThems.Load();
            Fine = db.FineThems.Local.ToObservableCollection();


        }
    }
}

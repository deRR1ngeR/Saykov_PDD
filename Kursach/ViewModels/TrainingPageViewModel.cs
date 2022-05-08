using Kursach.Models.Base;
using Kursach.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Kursach.ViewModels
{
    internal class TrainingPageViewModel
    {
     
     readonly SAYKOV_PDDContext db;
     public ObservableCollection<Ticket> Tkts { get; set; }
     public TrainingPageViewModel()
     {
         db = new SAYKOV_PDDContext();
         db.Tickets.Load();
         Tkts = db.Tickets.Local.ToObservableCollection();
     }
    }
}

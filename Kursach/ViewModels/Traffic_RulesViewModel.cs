﻿using Kursach.ViewModels.Base;
using Kursach.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Kursach.Models.Base;

namespace Kursach.ViewModels
{
   
    internal class Traffic_RulesViewModel: ViewModel
    {
        
        readonly SAYKOV_PDDContext db;
        public ObservableCollection<PddInfo> Info { get; set; }
        public Traffic_RulesViewModel()
        {

            db = new SAYKOV_PDDContext();
            db.PddInfos.Load();
            Info = db.PddInfos.Local.ToObservableCollection();
          
        }
        
    }
}
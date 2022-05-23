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
using System;

namespace Kursach.ViewModels
{
    internal class ProfilePageViewModel:ViewModel
    {
        private ObservableCollection<TicketResult> _tResults = new ObservableCollection<TicketResult>();
        public ObservableCollection<TicketResult> tResults
        {
            get => _tResults;
            set=>Set(ref _tResults, value);
        }

        public string 
            UserName { get; set; }
        public int PassedCount { get; set; } = 0;
        public int UnpassedCount { get; set; } = 0;
        public string 
            UserSurname { get; set; }
        
        public DateTime? regDate { get; set; }
        public ProfilePageViewModel()
        {
            
            ShowResult();
        }
        public void ShowResult()
        {
            var db = new SAYKOV_PDDContext();
            UserName = CurrentUser.getInstance().UserName;
            UserSurname = CurrentUser.getInstance().UserSurname;
            regDate = CurrentUser.getInstance().RegDate;
            var results = db.TicketResults.Where(t => t.UserId == CurrentUser.getInstance().UserId).ToList();
            foreach(var t in results)   
            {
                if (t.isPassed == true)
                    PassedCount++;
                else
                    UnpassedCount++;
                tResults.Add(t);
            }
        }
    }
}

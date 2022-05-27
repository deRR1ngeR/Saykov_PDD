using Kursach.Models.Base;
using Kursach.ViewModels.Base;
using Kursach.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kursach.Infrastructure.Commands;

namespace Kursach.ViewModels
{
    internal class AddTrafficViewModel: ViewModel
    {
        private SAYKOV_PDDContext db;
        private ObservableCollection<PddInfo> PddInfoColelction;
        private string _PDDInfoText;
        public string PDDInfoText
        {
            get => _PDDInfoText;
            set => Set(ref _PDDInfoText, value);
        }
        public AddTrafficViewModel()
        {
            db = new SAYKOV_PDDContext();
            PddInfoColelction = new ObservableCollection<PddInfo>(db.PddInfos.Local.ToList());
            AddPDDInfoCommand = new RelayCommand(OnAddPDDInfoCommandExecuted, CanAddPDDInfoCommandExecute);

        }
        public ICommand AddPDDInfoCommand { get; set; }
        public bool CanAddPDDInfoCommandExecute(object p) => true;
        public void OnAddPDDInfoCommandExecuted(object p)
        {
            bool flag = true;
            foreach(var t in PddInfoColelction)
            {
                if (t.PddText == PDDInfoText)
                    flag = false;
                    
            }
            if(flag == true)
            {
                db.PddInfos.Add(new PddInfo { PddText = PDDInfoText });
                db.SaveChanges();
            }
        }
    }
}

using Kursach.Infrastructure.Commands;
using Kursach.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursach.ViewModels
{
    internal class TicketPageViewModel
    {
  
        public int QstnId { get; set; } = 1;
        readonly SAYKOV_PDDContext db;
        public ObservableCollection<Question> questions { get; set; }
        public Question Qstn = null;
        public string Answer { get; set; }


        public TicketPageViewModel()
        {
            db = new SAYKOV_PDDContext();

            db.Questions.Load();
            ClickButtonIdCommand = new RelayCommand(OnClickButtonIdCommandExecuted, CanClickButtonIdCommandExecute);
            questions = new ObservableCollection<Question>();


         //    using (SAYKOV_PDDContext dbs = new SAYKOV_PDDContext())
         //    {
         //        Qstn = dbs.Questions.Where(b => b.QuestionId == QstnId).FirstOrDefault();
         //        questions.Add(Qstn);
         //    }

            questions = GetList();

        }
        #region Команды
        public ICommand ClickButtonIdCommand { get; set; }
        public void OnClickButtonIdCommandExecuted(object p)
        {
            var s = p as Button;
            string id = s.Name;
            id = id.Substring(2);
            using(SAYKOV_PDDContext db = new SAYKOV_PDDContext())
            {
                QstnId = Convert.ToInt32(id);
                questions = new ObservableCollection<Question>();
                Qstn = db.Questions.Where(b => b.QuestionId == QstnId).FirstOrDefault();

            }
            questions.Add(Qstn);
            

        }
        public ObservableCollection<Question> GetList()
        {
            return questions;
        }

        public bool CanClickButtonIdCommandExecute(object p) => true;
        #endregion
    }
}

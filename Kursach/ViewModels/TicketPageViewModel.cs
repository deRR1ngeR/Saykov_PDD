using Kursach.Infrastructure.Commands;
using Kursach.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Kursach.ViewModels.Base;
using System.Windows.Input;

namespace Kursach.ViewModels
{
    internal class TicketPageViewModel: ViewModel,INotifyPropertyChanged
    {

        private ObservableCollection<Question> _Questions;
        public int QstnId { get; set; } = 1;
        readonly SAYKOV_PDDContext db;
        public ObservableCollection<Answer> an { get; set; }
        public Answer SelectedAnswer { get; set; }
        public ObservableCollection<Question> questions { get { return _Questions; } set { _Questions = value; OnPropertyChanged("questions"); } }
        public Question Qstn = null;
        private ObservableCollection<Answer> _Answers;
        public ObservableCollection<Answer> Answers { get
            {
                return _Answers;
            } 
            set
            {
                _Answers = value;
                OnPropertyChanged("Answers");
            } }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public TicketPageViewModel()
        {
            db = new SAYKOV_PDDContext();

            db.Questions.Load();
            db.Answers.Load();
            ClickButtonIdCommand = new RelayCommand(OnClickButtonIdCommandExecuted, CanClickButtonIdCommandExecute);
            an = db.Answers.Local.ToObservableCollection();
        }
        
        #region Команды
        public ICommand ClickButtonIdCommand { get; set; }
        public void OnClickButtonIdCommandExecuted(object p)
        {
            var s = p as Button;
            string id = s.Name;
            id = id.Substring(2);
               QstnId = Convert.ToInt32(id);
                questions = new ObservableCollection<Question>();
            Answers = new ObservableCollection<Answer>();
            using(SAYKOV_PDDContext db = new SAYKOV_PDDContext())
            {
                Qstn = db.Questions.Where(b => b.QuestionId == QstnId).FirstOrDefault();        
            }

            var ansrs = from t in an
                        where t.QuestionId == QstnId
                        select t;
            
            foreach(var t in ansrs)
            {
                Answers.Add(t);
            }
           
        }
      
        public bool CanClickButtonIdCommandExecute(object p) => true;
        #endregion
    }
}

using Kursach.Infrastructure.Commands;
using Kursach.Models.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Kursach.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;


namespace Kursach.ViewModels
{
    internal class TicketPageViewModel : ViewModel, INotifyPropertyChanged
    {
        private Visibility _Visible;
        public Visibility Visible
        {
            get
            {
                return _Visible;
            }
            set
            {
                _Visible = value;
                OnPropertyChanged("Visible");
            }
        }
        private TicketPage _OptionPage;
        public TicketPage OptionPage
        {
            get
            {
                return _OptionPage;
            }
            set
            {
                _OptionPage = value;
                OnPropertyChanged("OptionPage");
            }
        }
        private string _Result;

        public string Result
        {
            get
            {
                return _Result;
            }
            set
            {
                _Result = value;
                OnPropertyChanged("Result");
            }
        }
        private string _UrAnswer;
        public string UrAnswer
        {
            get
            {
                return _UrAnswer;
            }
            set
            {
                _UrAnswer = value;
                OnPropertyChanged("UrAnswer");
            }
        }
        private ObservableCollection<Question> _Questions;
        private SolidColorBrush _Resultcolor;
        public SolidColorBrush Resultcolor
        {
            get
            {
                return _Resultcolor;
            }
            set
            {
                _Resultcolor = value;
                OnPropertyChanged("Resultcolor");
            }
        }
        private SolidColorBrush _Startcolor;
        public SolidColorBrush Startcolor
        {
            get
            {
                return _Startcolor;
            }
            set
            {
                _Startcolor = value;
                OnPropertyChanged("Startcolor");
            }
        }

        public int QstnId { get; set; } = 1;
        public string btnid { get; set; }
        readonly SAYKOV_PDDContext db;
        DispatcherTimer _timer;
        TimeSpan _time;
        private string _qstnText;
        public string qstnText
        {
            get
            {
                return _qstnText;
            }
            set
            {
                _qstnText = value;
                OnPropertyChanged("qstnText");
            }
        }
        private string _tbTime;
        public string tbTime
        {
            get
            {
                return _tbTime;
            }
            set
            {
                _tbTime = value;
                OnPropertyChanged("tbTime");
            }
        }
        public ObservableCollection<Answer> an { get; set; }
        public ObservableCollection<Question> questions { get { return _Questions; } set { _Questions = value; OnPropertyChanged("questions"); } }
        public Question Qstn = null;
        private ObservableCollection<Answer> _Answers;
        private Answer selectedAnswer;
        public Answer SelectedAnswer
        {
            get { return selectedAnswer; }
            set
            {
                Set(ref selectedAnswer, value);

                AnswerClickCommands();
            }


        }

        private void AnswerClickCommands()
        {
            int i = 1;
            Visible = Visibility.Visible;
            foreach (var t in Answers)
            {
                if (selectedAnswer != t)
                {
                    i++;
                }
            }

            if (selectedAnswer != null)
            {

                if (SelectedAnswer.RightAnswer == true)
                {
                    

                    Startcolor = Brushes.LightGreen;
                    MessageBox.Show("Верно!");
                    Resultcolor = Brushes.LightGreen;
                    Result = "Правильно";
                    UrAnswer = "Ваш ответ: " + i;
                }
                else
                {
                    
                    Result = "Неправильно";
                    Resultcolor = Brushes.Red;
                    Startcolor = Brushes.Red;
                    foreach (var t in Answers)
                    {
                        if (t.RightAnswer == true)
                        {
                            MessageBox.Show("Правильный ответ  - " + t.Answer1);
                            break;
                        }
                    }
                }
            }
        }

        public ObservableCollection<Answer> Answers
        {
            get
            {
                return _Answers;
            }
            set
            {
                _Answers = value;
                OnPropertyChanged("Answers");
            }
        }
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
            StartTicketCommand = new RelayCommand(OnStartTicketCommandExecuted, CanStartTicketCommandExecute);
            ClickButtonIdCommand = new RelayCommand(OnClickButtonIdCommandExecuted, CanClickButtonIdCommandExecute);
            an = db.Answers.Local.ToObservableCollection();

            Startcolor = Brushes.LightGray;
        }
        public void Timer()
        {

            _time = TimeSpan.FromSeconds(900);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime = _time.ToString("c");

                if (_time == TimeSpan.Zero) _timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }

        #region Команды
        public ICommand ClickButtonIdCommand { get; set; }
        public void OnClickButtonIdCommandExecuted(object p)
        {
            var s = p as Button;

            string id = s.Name;
            btnid = id;
            id = id.Substring(2);

            QstnId = Convert.ToInt32(id);


            Answers = new ObservableCollection<Answer>();
            using (SAYKOV_PDDContext db = new SAYKOV_PDDContext())
            {
                Qstn = db.Questions.Where(b => b.NumberInTicket == QstnId).FirstOrDefault();

                qstnText = Qstn.QuestionText;

            }

            var ansrs = from t in an
                        where t.QuestionId == QstnId
                        select t;

            foreach (var t in ansrs)
            {
                Answers.Add(t);
            }
            
        }

        public bool CanClickButtonIdCommandExecute(object p) => true;

        public ICommand StartTicketCommand { get; set; }
        public void OnStartTicketCommandExecuted(object p)
        {
            OptionPage = (TicketPage)p;
            string id = OptionPage.bt1.Name;
            var btnid = id;
            id = id.Substring(2);
            QstnId = Convert.ToInt32(id);
            Answers = new ObservableCollection<Answer>();
            using (SAYKOV_PDDContext db = new SAYKOV_PDDContext())
            {
                Qstn = db.Questions.Where(b => b.NumberInTicket == QstnId).FirstOrDefault();

                qstnText = Qstn.QuestionText;

            }

            var ansrs = from t in an
                        where t.QuestionId == QstnId
                        select t;

            foreach (var t in ansrs)
            {
                Answers.Add(t);
            }
            if (btnid == "bt1")
            {
                OptionPage.bt1.Visibility = Visibility.Hidden;
                Timer();
            }
        }

        public bool CanStartTicketCommandExecute(object p) => true;
        #endregion
    }
}

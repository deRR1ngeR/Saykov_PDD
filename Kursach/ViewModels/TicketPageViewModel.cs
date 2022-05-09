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
using System.Collections;

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
        public ArrayList answered = new ArrayList();
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
        private ImageSource sourceIn;
        public ImageSource SourceIn
        {
            get => sourceIn;
            set => Set(ref sourceIn, value);
        }
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
                    #region
                    if (OptionPage.bt1.Name == btnid)
                    {
                        OptionPage.id1.Background = Brushes.LightGreen;
                    }
                    if (OptionPage.id1.Name == btnid)
                    {
                        OptionPage.id1.Background = Brushes.LightGreen;
                    }
                    if (OptionPage.id2.Name == btnid)
                    {
                        OptionPage.id2.Background = Brushes.LightGreen;
                    }
                    if (OptionPage.id3.Name == btnid)
                    {
                        OptionPage.id3.Background = Brushes.LightGreen;
                    }
                    if (OptionPage.id4.Name == btnid)
                    {
                        OptionPage.id4.Background = Brushes.LightGreen;
                    }
                    if (OptionPage.id5.Name == btnid)
                    {
                        OptionPage.id5.Background = Brushes.LightGreen;
                    }
                    if (OptionPage.id6.Name == btnid)
                    {
                        OptionPage.id6.Background = Brushes.LightGreen;
                    }
                    if (OptionPage.id7.Name == btnid)
                    {
                        OptionPage.id7.Background = Brushes.LightGreen;
                    }
                    if (OptionPage.id8.Name == btnid)
                    {
                        OptionPage.id8.Background = Brushes.LightGreen;
                    }
                    if (OptionPage.id9.Name == btnid)
                    {
                        OptionPage.id9.Background = Brushes.LightGreen;
                    }
                    if (OptionPage.id10.Name == btnid)
                    {             
                        OptionPage.id10.Background = Brushes.LightGreen;
                    }
                    #endregion условия
                    MessageBox.Show("Верно!");
                    Resultcolor = Brushes.LightGreen;
                    Result = "Правильно";
                    UrAnswer = "Ваш ответ: " + i;
                    answered.Add(Qstn.NumberInTicket);
                }
                else
                {
                    #region 
                    if (OptionPage.id1.Name == btnid)
                    {
                        OptionPage.id1.Background = Brushes.Red;
                    }
                    if (OptionPage.id2.Name == btnid)
                    {
                        OptionPage.id2.Background = Brushes.Red;
                    }
                    if (OptionPage.id3.Name == btnid)
                    {
                        OptionPage.id3.Background = Brushes.Red;
                    }
                    if (OptionPage.id4.Name == btnid)
                    {
                        OptionPage.id4.Background = Brushes.Red;
                    }
                    if (OptionPage.id5.Name == btnid)
                    {
                        OptionPage.id5.Background = Brushes.Red;
                    }
                    if (OptionPage.id6.Name == btnid)
                    {
                        OptionPage.id6.Background = Brushes.Red;
                    }
                    if (OptionPage.id7.Name == btnid)
                    {
                        OptionPage.id7.Background = Brushes.Red;
                    }
                    if (OptionPage.id8.Name == btnid)
                    {
                        OptionPage.id8.Background = Brushes.Red;
                    }
                    if (OptionPage.id9.Name == btnid)
                    {
                        OptionPage.id9.Background = Brushes.Red;
                    }
                    if (OptionPage.id10.Name == btnid)
                    {
                        OptionPage.id10.Background = Brushes.Red;
                    }
#endregion  условия
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
                    answered.Add(Qstn.NumberInTicket);
                }
            }
        }
        public void NextQuestion()
        {
            

            string id = btnid.Substring(2);
            
            QstnId = Convert.ToInt32(id) + 1;
            int k =0;
            int o = 1;
            while (o < 11)
            {
                k = 0;
                foreach (int t in answered)
                {
                    if (t == o)
                        k++;
                }
                if (k == 0) 
                { 
                    
                    QstnId = o;
                    btnid = "id" + QstnId;

                    break;
                }
                o++;
            }
            
            Answers = new ObservableCollection<Answer>();
            
           if (QstnId<10 && QstnId>0)
            using (SAYKOV_PDDContext db = new SAYKOV_PDDContext())
            {
                Qstn = db.Questions.Where(b => b.NumberInTicket == QstnId).FirstOrDefault();
                    qstnText = Qstn.NumberInTicket + ". " + Qstn.QuestionText;
            }
            if (Qstn == null)
                NextQuestion();
            
            
              
            
            var ansrs = from t in an
                        where t.QuestionId == QstnId
                        select t;

            foreach (var t in ansrs)
            {
                Answers.Add(t);
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
            NextQuestionCommand = new RelayCommand(OnNextQuestionCommandExecuted, CanNextQuestionCommandExecute);
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

                if (_time == TimeSpan.Zero) { _timer.Stop();
                    MessageBox.Show("Время вышло!");
                }

                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            
            _timer.Start();
            
        }

        #region Команды
        public ICommand NextQuestionCommand { get; set; }
        public void OnNextQuestionCommandExecuted(object p)
        {
            NextQuestion();
            Visible = Visibility.Hidden;
        }
        public bool CanNextQuestionCommandExecute(object p) => true;
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

                qstnText =Qstn.NumberInTicket + ". " + Qstn.QuestionText;

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
            btnid = id;
            id = id.Substring(2);
            QstnId = Convert.ToInt32(id);
            Answers = new ObservableCollection<Answer>();
            using (SAYKOV_PDDContext db = new SAYKOV_PDDContext())
            {
                Qstn = db.Questions.Where(b => b.NumberInTicket == QstnId).FirstOrDefault();

                qstnText = Qstn.NumberInTicket + ". " + Qstn.QuestionText;


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
            OptionPage.qstnbtn.Visibility = Visibility.Visible;
        }

        public bool CanStartTicketCommandExecute(object p) => true;
        #endregion
    }
}

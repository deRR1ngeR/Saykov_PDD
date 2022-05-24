using Kursach.Infrastructure.Commands;
using Kursach.Models;
using Kursach.Models.Base;
using Kursach.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kursach.ViewModels
{
    internal class AddAnswersPageViewModel: ViewModel
    {
        private readonly SAYKOV_PDDContext db;
        private ObservableCollection<Question> _QstnCollection;
        public ObservableCollection<Question> QstnCollection
        {
            get => _QstnCollection;
            set=>Set(ref _QstnCollection, value);
        }
        #region Ответы (свойства)
        private string _Answer1;
        public string Answer1
        {
            get => _Answer1;
            set => Set(ref _Answer1, value);
        }
        private string _Answer2;
        public string Answer2
        {
            get => _Answer2;
            set => Set(ref _Answer2, value);
        }
        private string _Answer3;
        public string Answer3
        {
            get => _Answer3;
            set => Set(ref _Answer3, value);
        }
        private string _Answer4;
        public string Answer4
        {
            get => _Answer4;
            set => Set(ref _Answer4, value);
        }
        private string _Answer5;
        public string Answer5
        {
            get => _Answer5;
            set => Set(ref _Answer5, value);
        }
        private string _TrueAnswer1;
        public string TrueAnswer1
        {
            get => _TrueAnswer1;
            set => Set(ref _TrueAnswer1, value);
        }
        private string _TrueAnswer2;
        public string TrueAnswer2
        {
            get => _TrueAnswer2;
            set => Set(ref _TrueAnswer2, value);
        }
        private string _TrueAnswer3;
        public string TrueAnswer3
        {
            get => _TrueAnswer3;
            set => Set(ref _TrueAnswer3, value);
        }
        private string _TrueAnswer4;
        public string TrueAnswer4
        {
            get => _TrueAnswer4;
            set => Set(ref _TrueAnswer4, value);
        }
        private string _TrueAnswer5;
        public string TrueAnswer5
        {
            get => _TrueAnswer5;
            set => Set(ref _TrueAnswer5, value);
        }
        #endregion
        private ObservableCollection<Answer> _AnswersCollection;
        public ObservableCollection<Answer> AnswersCollection
        {
            get => _AnswersCollection;
            set => Set(ref _AnswersCollection, value);
        }
        private int _TicketsCount;
        public int TicketsCount { get =>_TicketsCount; set=>Set(ref _TicketsCount,value); }
        public int _TicketId;
        public int QstnId { get=> _TicketId; set=>Set(ref _TicketId,value); }


        public AddAnswersPageViewModel()
        {
            db = new SAYKOV_PDDContext();
            QstnCollection = new ObservableCollection<Question>(db.Questions.ToList());
            AnswersCollection = new ObservableCollection<Answer>(db.Answers.ToList());
            TicketsCount = QstnCollection.Count();
            AddAnswersCommand = new RelayCommand(OnAddAnswersCommandExecuted, CanAddAnswersCommandExecute);
        }
        public ICommand AddAnswersCommand { get; set; }
        public bool CanAddAnswersCommandExecute(object p) => true;
        public void OnAddAnswersCommandExecuted(object p)
        {
            bool isRight = false;
            if(Answer1 != null)
            {
                if (TrueAnswer1 == null)
                {
                    MessageBox.Show("Заполните поля: правильный ответ");
                }
                else
                {
                    if (TrueAnswer1 == "Да")
                        isRight = true;
                    else if (TrueAnswer1 == "Нет")
                        isRight = false;
                     db.Answers.Add(new Answer { Answer1 = Answer1, QuestionId = QstnId, RightAnswer = isRight });
                }

            }if(Answer2 != null)
            {
                if (TrueAnswer2 == null)
                {
                    MessageBox.Show("Заполните поля: правильный ответ");
                }
                else
                {
                    if (TrueAnswer2 == "Да")
                        isRight = true;
                    else if (TrueAnswer2 == "Нет")
                        isRight = false;
                     db.Answers.Add(new Answer { Answer1 = Answer2, QuestionId = QstnId, RightAnswer = isRight });
                }

            }if(Answer3 != null)
            {
                if (TrueAnswer3 == null)
                {
                    MessageBox.Show("Заполните поля: правильный ответ");
                }
                else
                {
                    if (TrueAnswer3 == "Да")
                        isRight = true;
                    else if (TrueAnswer3 == "Нет")
                        isRight = false;
                     db.Answers.Add(new Answer { Answer1 = Answer3, QuestionId = QstnId, RightAnswer = isRight });
                }

            }if(Answer4 != null)
            {
                if (TrueAnswer4 == null)
                {
                    MessageBox.Show("Заполните поля: правильный ответ");
                }
                else
                {
                    if (TrueAnswer4 == "Да")
                        isRight = true;
                    else if (TrueAnswer4 == "Нет")
                        isRight = false;
                     db.Answers.Add(new Answer { Answer1 = Answer4, QuestionId = QstnId, RightAnswer = isRight });
                }

            }if(Answer5 != null)
            {
                if (TrueAnswer1 == null)
                {
                    MessageBox.Show("Заполните поля: правильный ответ");
                }
                else
                {
                    if (TrueAnswer5 == "Да")
                        isRight = true;
                    else if (TrueAnswer5 == "Нет")
                        isRight = false;
                     db.Answers.Add(new Answer { Answer1 = Answer5, QuestionId = QstnId, RightAnswer = isRight });
                }

            }
        }
    }
}

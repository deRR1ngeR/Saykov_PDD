using Kursach.Infrastructure.Commands;
using Kursach.Models;
using Kursach.Models.Base;
using Kursach.ViewModels.Base;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
using System.Windows;
using System.Text.RegularExpressions;

namespace Kursach.ViewModels
{
    internal class AddTicketViewModel : ViewModel
    {
        private SAYKOV_PDDContext db;
        

        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog();
        private int _TicketId;
        public int TicketId
        {
            get => _TicketId;
            set => Set(ref _TicketId, value);
        }
        private string _ImagePath;
        public string ImagePath
        {
            get => _ImagePath;
            set => Set(ref _ImagePath, value);
        }
        private int _QstnId;
        public int QstnId
        {
            get => _QstnId;
            set => Set(ref _QstnId, value);
        }
        private int _QstnCount;
        public int QstnCount
        {
            get => _QstnCount;
            set => Set(ref _QstnCount, value);
        }
        private string _QstnText;
        public string QstnText
        {
            get => _QstnText;
            set => Set(ref _QstnText, value);
        }
        private ObservableCollection<Ticket> _TicketsCollection;
        public ObservableCollection<Ticket> TicketsCollection
        {
            get => _TicketsCollection;
            set => Set(ref _TicketsCollection, value);
        }

        private ObservableCollection<Question> _QstnsCollection;
        public ObservableCollection<Question> QstnsCollection
        {
            get => _QstnsCollection;
            set => Set(ref _QstnsCollection, value);
        }


        private int _NumberInTicket;
        public int NumberInTicket { get => _NumberInTicket; set => Set(ref _NumberInTicket, value); }

       
        public AddTicketViewModel()
        {
            db = new SAYKOV_PDDContext();
            TicketsCollection = new ObservableCollection<Ticket>(db.Tickets.ToList());
            QstnsCollection = new ObservableCollection<Question>(db.Questions.ToList());
            QstnCount = QstnsCollection.Count();
            AddImageCommand = new RelayCommand(OnAddImageCommandExecuted, CanAddImageCommandExecute);
            AddQuestionCommand = new RelayCommand(OnAddQuestionCommandExecuted, CanAddQuestionCommandExecute);
        }
        public ICommand AddQuestionCommand { get; set; }
        public bool CanAddQuestionCommandExecute(object p) => true;
        public void OnAddQuestionCommandExecuted(object p)
        {
            bool flag = false;
            using (var db = new SAYKOV_PDDContext())
            {
                foreach (var ticket in TicketsCollection)
                {
                    if (TicketId == ticket.TicketId)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag != true)
                {
                    db.Tickets.Add(new Ticket { TicketId = this.TicketId });
                    db.SaveChanges();
                }

                flag = false;
                foreach (var question in QstnsCollection)
                {
                    if (QstnId == question.QuestionId)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag != true)
                {
                    db.Questions.Add(new Question { QuestionId = QstnId, QuestionText = QstnText, TicketId = this.TicketId, QuestionImg = ImagePath, NumberInTicket = this.NumberInTicket });
                    db.SaveChanges();
                }
                
            }
        }
        public ICommand AddImageCommand { get; set; }
        public bool CanAddImageCommandExecute(object p) => true;
        public void OnAddImageCommandExecuted(object p)
        {
            _openFileDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)" +
                                 "|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            _openFileDialog.ShowDialog();
            ImagePath = _openFileDialog.FileName;
        }
        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-zA-я<>%$?!&_/^*@#()+=:;'\\s]");
            regex.Replace(" ", "");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

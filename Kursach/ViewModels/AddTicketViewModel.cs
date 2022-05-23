using Kursach.Infrastructure.Commands;
using Kursach.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kursach.ViewModels
{
    internal class AddTicketViewModel: ViewModel
    {
        private int _TicketId;
        public int TicketId
        {
            get => _TicketId;
            set => Set(ref _TicketId, value);
        }
        private int _QstnId;
        public int QstnId
        {
            get => _QstnId;
            set => Set(ref _QstnId, value);
        }
        private string _QstnText;
        public string QstnText
        {
            get => _QstnText;
            set => Set(ref _QstnText, value);
        }
        private string _ImgSource;
        public string ImgSource { get=> _ImgSource; set => Set(ref _ImgSource, value); }
        private string _NumberInTicket;
        public string NumberInTicket { get => _NumberInTicket; set => Set(ref _NumberInTicket, value); }

        public AddTicketViewModel()
        {
            AddAnswersCommand = new RelayCommand(OnAddAnswersCommandExecuted, CanAddAnswersCommandExecute);
        }

        public ICommand AddAnswersCommand { get; set; }
        public bool CanAddAnswersCommandExecute(object p) => true;
        public void OnAddAnswersCommandExecuted(object p)
        {

        }
    }
}

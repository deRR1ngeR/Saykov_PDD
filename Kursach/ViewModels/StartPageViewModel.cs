using Kursach.Infrastructure.Commands;
using Kursach.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kursach.ViewModels
{
    internal class StartPageViewModel : ViewModel
    {
        private ViewModel _ShowingViewModel;
        public ViewModel ShowingViewModel
        {
            get { return _ShowingViewModel; }
            set => Set(ref _ShowingViewModel, value);
        }
        public RelayCommand ChangeCommand { get; set; }
        public StartPageViewModel(StartPageViewModel startPageViewModel)
        {
            ShowingViewModel = new StartPageViewModel(this);
            ChangeCommand = new RelayCommand((name) =>
            {
                switch (name.ToString())
                {
                    case "home":
                        if (ShowingViewModel.GetType().Name != "StartPageViewModel")
                            ShowingViewModel = new StartPageViewModel(this);
                        break;
                    case "rules":
                        if (ShowingViewModel.GetType().Name != "Traffic_RulesViewModel")
                            ShowingViewModel = new Traffic_RulesViewModel();
                        break;
                    case "forfeit":
                        if (ShowingViewModel.GetType().Name != "Forfeit_pageViewModel")
                            ShowingViewModel = new Forfeit_pageViewModel();
                        break;
                    case "train":
                        if (ShowingViewModel.GetType().Name != "TrainingPageViewModel")
                            ShowingViewModel = new TrainingPageViewModel();
                        break;
                    case "ticket":
                        if (ShowingViewModel.GetType().Name != "OrderPageContentViewModel")
                            ShowingViewModel = new TicketPageViewModel();
                        break;
                }
            });
        }
    }
}

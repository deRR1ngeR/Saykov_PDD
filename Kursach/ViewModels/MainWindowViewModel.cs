using Kursach.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {

        #region Заголовок окна
        private string _Title = "Login Window";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

    }
}

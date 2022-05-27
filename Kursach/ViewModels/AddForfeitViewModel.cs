using Kursach.Infrastructure.Commands;
using Kursach.Models;
using Kursach.Models.Base;
using Kursach.ViewModels.Base;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kursach.ViewModels
{
    internal class AddForfeitViewModel: ViewModel
    {
        private readonly SAYKOV_PDDContext db;
        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog();
        private string _ImagePath;
        public string ImagePath
        {
            get => _ImagePath;
            set => Set(ref _ImagePath, value);
        }
        private int _ThemId;
        public int ThemId
        {
            get => _ThemId;
            set => Set(ref _ThemId, value);
        }
        private int _ThemCount;
        public int ThemCount
        {
            get => _ThemCount;
            set => Set(ref _ThemCount, value);
        }
        private string _ForfeitThem;
        public string ForfeitThem
        {
            get => _ForfeitThem;
            set => Set(ref _ForfeitThem, value);
        }
        private string _ForfeitText;
        public string ForfeitText
        {
            get => _ForfeitText;
            set => Set(ref _ForfeitText, value);
        }
        private string _ForfeitTime;
        public string ForfeitTime
        {
            get => _ForfeitTime;
            set => Set(ref _ForfeitTime, value);
        }
        private string _ForfeitCost;
        public string ForfeitCost
        {
            get => _ForfeitCost;
            set => Set(ref _ForfeitCost, value);
        }




        public AddForfeitViewModel()
        {
            db = new SAYKOV_PDDContext();
            ThemCount = db.FineThems.Count();
            AddImageCommand = new RelayCommand(OnAddImageCommandExecuted, CanAddImageCommandExecute);
            AddForfeitInfoCommand = new RelayCommand(OnAddForfeitInfoCommandexecuted, CanAddForfeitInfoCommandExecute);
        }
        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-zA-я<>%$?!&_/^*@#()+=:;'\\s]");
            regex.Replace(" ", "");
            e.Handled = regex.IsMatch(e.Text);
        }
        public ICommand AddForfeitInfoCommand { get; set; }
        public bool CanAddForfeitInfoCommandExecute(object p) => true;
        public void OnAddForfeitInfoCommandexecuted(object p)
        {
            if (ForfeitThem != null)
                db.FineThems.Add(new FineThem { FineText = ForfeitThem });
            db.SaveChanges();

            db.Fines.Add(new Fine { FineThemId = ThemId, FineText = ForfeitText, FineCost = ForfeitCost, FineTime = ForfeitTime, FineImg = ImagePath });
            db.SaveChanges();
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
    }
}

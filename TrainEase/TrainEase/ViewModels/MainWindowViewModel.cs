using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrainEase.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private TrainViewModel _trainViewModel;

        public TrainViewModel TrainViewModel
        {
            get => _trainViewModel;
            set
            {
                _trainViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            // Initialize your view models here
            TrainViewModel = new TrainViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

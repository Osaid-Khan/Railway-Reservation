using System.Collections.ObjectModel;
using System.Windows.Input;
using TrainEase.DataAccess;
using TrainEase.Models;

namespace TrainEase.ViewModels
{
    public class TrainViewModel : ViewModelBase
    {
        private TrainRepository _trainRepository;

        public ObservableCollection<Train> Trains { get; set; }
        public ICommand LoadTrainsCommand { get; set; }

        public TrainViewModel()
        {
            _trainRepository = new TrainRepository();
            Trains = new ObservableCollection<Train>();

            LoadTrainsCommand = new RelayCommand(LoadTrains);
        }

        private void LoadTrains()
        {
            Trains.Clear();
            var trains = _trainRepository.GetAllTrains();
            foreach (var train in trains)
            {
                Trains.Add(train);
            }
        }
    }

}

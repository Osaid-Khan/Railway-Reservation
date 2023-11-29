using System.Collections.ObjectModel;
using System.Windows.Input;
using TrainEase.DataAccess;
using TrainEase.Models;


namespace TrainEase.ViewModels
{
    public class BookingViewModel : ViewModelBase
    {
        private BookingRepository _bookingRepository;

        public ObservableCollection<Booking> Bookings { get; set; }
        public ICommand LoadBookingsCommand { get; set; }

        public BookingViewModel()
        {
            _bookingRepository = new BookingRepository();
            Bookings = new ObservableCollection<Booking>();

            LoadBookingsCommand = new RelayCommand(LoadBookings);
        }

        private void LoadBookings()
        {
            Bookings.Clear();
            var bookings = _bookingRepository.GetAllBookings();
            foreach (var booking in bookings)
            {
                Bookings.Add(booking);
            }
        }
    }

}

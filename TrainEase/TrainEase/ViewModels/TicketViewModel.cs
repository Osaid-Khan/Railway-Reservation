using System.Collections.ObjectModel;
using System.Windows.Input;
using TrainEase.DataAccess;
using TrainEase.Models;


namespace TrainEase.ViewModels
{
    public class TicketViewModel : ViewModelBase
    {
        private TicketRepository _ticketRepository;

        public ObservableCollection<Ticket> Tickets { get; set; }
        public ICommand LoadTicketsCommand { get; set; }

        public TicketViewModel()
        {
            _ticketRepository = new TicketRepository();
            Tickets = new ObservableCollection<Ticket>();

            LoadTicketsCommand = new RelayCommand(LoadTickets);
        }

        private void LoadTickets()
        {
            Tickets.Clear();
            var tickets = _ticketRepository.GetAllTickets();
            foreach (var ticket in tickets)
            {
                Tickets.Add(ticket);
            }
        }
    }

}

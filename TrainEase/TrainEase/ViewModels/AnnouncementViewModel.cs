using System.Collections.ObjectModel;
using System.Windows.Input;
using TrainEase.DataAccess;
using TrainEase.Models;

namespace TrainEase.ViewModels
{

    public class AnnouncementViewModel : ViewModelBase
    {
        private AnnouncementRepository _announcementRepository;

        public ObservableCollection<Announcement> Announcements { get; set; }
        public ICommand LoadAnnouncementsCommand { get; set; }

        public AnnouncementViewModel()
        {
            _announcementRepository = new AnnouncementRepository();
            Announcements = new ObservableCollection<Announcement>();

            LoadAnnouncementsCommand = new RelayCommand(LoadAnnouncements);
        }

        private void LoadAnnouncements()
        {
            Announcements.Clear();
            var announcements = _announcementRepository.GetAllAnnouncements();
            foreach (var announcement in announcements)
            {
                Announcements.Add(announcement);
            }
        }
    }

}

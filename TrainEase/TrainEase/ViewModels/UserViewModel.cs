using System.Collections.ObjectModel;
using System.Windows.Input;
using TrainEase.DataAccess;
using TrainEase.Models;


namespace TrainEase.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private UserRepository _userRepository;

        public ObservableCollection<User> Users { get; set; }
        public ICommand LoadUsersCommand { get; set; }

        public UserViewModel()
        {
            _userRepository = new UserRepository();
            Users = new ObservableCollection<User>();

            LoadUsersCommand = new RelayCommand(LoadUsers);
        }

        private void LoadUsers()
        {
            Users.Clear();
            var users = _userRepository.GetAllUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }

}

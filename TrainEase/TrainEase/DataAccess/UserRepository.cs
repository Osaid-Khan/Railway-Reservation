using System;
using System.Collections.Generic;
using System.Linq;
using TrainEase.Models;

namespace TrainEase.DataAccess
{
    

    public class UserRepository
    {
        private readonly TrainTicketDbContext _dbContext;

        public UserRepository()
        {
            _dbContext = new TrainTicketDbContext();
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserID == userId);
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _dbContext.Users.Find(user.UserID);
            if (existingUser != null)
            {
                // Update properties of existingUser with the values of user
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                // Update other properties...

                existingUser.UpdatedAt = DateTime.Now;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _dbContext.Users.Find(userId);
            if (userToDelete != null)
            {
                _dbContext.Users.Remove(userToDelete);
                _dbContext.SaveChanges();
            }
        }
    }

}

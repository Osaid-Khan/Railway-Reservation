// SignUp.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;
using TrainEase.Data;
using TrainEase.Models;

namespace TrainEase
{
    public partial class SignUp : UserControl
    {
        public EventHandler eve;
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = txtNewUsername.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string newPassword = txtNewPassword.Password;

            if (CreateNewUser(newUsername, firstName, lastName, email, newPassword))
            {
                MessageBox.Show("Sign-up successful!");
                SignUpCompleted();
            }
            else
            {
                lblSignUpError.Visibility = Visibility.Visible;
                lblSignUpError.Text = "Error creating a new user.";
            }
        }

        private void SignUpCompleted()
        {
            // Implement the logic you want to execute when sign-up is completed
        }

        private bool CreateNewUser(string newUsername, string firstName, string lastName, string email, string newPassword)
        {
            try
            {
                using (var context = new TrainEaseDbContext())
                {
                    var newUser = new User
                    {
                        Username = newUsername,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        Password = newPassword,
                        Status = "Active", // Set default status or provide user input
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        UserRole = "Passenger"
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

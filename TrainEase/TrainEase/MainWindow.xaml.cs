using System;
using System.Linq;
using System.Windows;
using TrainEase.Data;

namespace TrainEase
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (IsValidUser(username, password))
            {
                // Navigate to the main application window or perform other actions
                MessageBox.Show("Login successful!");
            }
            else
            {
                lblLoginError.Visibility = Visibility.Visible;
                lblLoginError.Text = "Invalid username or password.";
            }
        }
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUpControl = new SignUp();
            signUpControl.eve += SignUpControl_SignUpCompleted;

            // Create a pop-up window and set its content to the SignUp user control
            Window signUpWindow = new Window
            {
                Title = "Sign Up",
                Content = signUpControl,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };

            // Show the pop-up window
            signUpWindow.ShowDialog();
        }

        private void SignUpControl_SignUpCompleted(object sender, System.EventArgs e)
        {
            // Handle sign-up completion, e.g., close the sign-up window or navigate to the main application window
            MessageBox.Show("Sign-up successful!");
        }
        private bool IsValidUser(string username, string password)
        {
            // Add logic to check if the user exists in the database
            // For demonstration purposes, let's assume there is a Users table
            // in your TrainEaseDBContext with columns Username and Password
            using (var context = new TrainEaseDbContext())
            {
                return context.Users.Any(u => u.Username == username && u.Password == password);
            }
        }
    }
}

using System.Windows;
using Model;

namespace ChessApp
{

    public partial class AddUsers : Window
    {
        public static SqlDatabase db = MainWindow.db;
        public AddUsers()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (textUserName.Text == "" || textEmail.Text == "" || textPassword.Text == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            User user = new User()
            { 
                userName = textUserName.Text,
                email = textEmail.Text,
                password = textPassword.Text, 
            };
            long result = db.AddUser(user);
            user.codUser = result;
            if (result > 0)
            {
                MessageBox.Show("User added successfully");
            }
            else
            {
                if (result == -1)
                    MessageBox.Show("Email already exists");
                else if (result == -2)
                    MessageBox.Show("Username is invalid");
                else
                MessageBox.Show("Password is invalid");
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

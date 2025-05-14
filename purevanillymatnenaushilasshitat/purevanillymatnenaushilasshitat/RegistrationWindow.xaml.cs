using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace purevanillymatnenaushilasshitat
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private string connectionString = "server=localhost;user=root;password=Test!2345;database=kanstov;";

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
            using var checkCmd = new MySqlCommand(checkQuery, connection);
            checkCmd.Parameters.AddWithValue("@username", username);

            var exists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;

            if (exists)
            {
                MessageBox.Show("Пользователь с таким именем уже существует.");
                return;
            }

            string query = "INSERT INTO users (username, password_hash, role_id) VALUES (@username, @password, 2)";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Регистрация успешна.");
            new LoginWindow().Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}

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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string connectionString = "server=localhost;user=root;password=Test!2345;database=kanstov;";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            string connectionString = "server=localhost;user=root;password=Test!2345;database=kanstov;";

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = @"
        SELECT u.username, r.name AS role
        FROM users u
        JOIN roles r ON u.role_id = r.id
        WHERE u.username = @username AND u.password_hash = @password;
    ";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                username = reader["username"].ToString(); 
                string role = reader["role"].ToString();

                LoggedUser.Username = username;
                LoggedUser.Role = role;

                LoginSuccessful(username, role);

                MessageBox.Show($"Добро пожаловать\n" +
                                $"Имя пользователя: {username}\n" +
                                $"Роль: {role}",
                                "Вход выполнен", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string LoggedInUsername { get; private set; }
        public string LoggedInRole { get; private set; }

        private void LoginSuccessful(string username, string role)
        {
            LoggedInUsername = username;
            LoggedInRole = role;
            DialogResult = true;
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow regWindow = new();
            regWindow.Show();
            this.Close();
        }
    }
}

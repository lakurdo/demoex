using chetirehpalubnik;
using chetirehpalubnik.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Tovar> itemColl { get; set; } = new();
        private List<Tovar> allItems = new();

        public MainWindow()
        {
            InitializeComponent();
            itemColl = new ObservableCollection<Tovar>();
            LoadItems();
        }

        private readonly Database _database = new();

        private void LoadItems()
        {
            var imagesFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
            var defaultImagePath = System.IO.Path.Combine(imagesFolder, "picture.png");
            var items = _database.GetTovars();
            allItems = items.ToList();
            MessageBox.Show($"Загружено товаров: {items}");

            foreach (var item in items)
            {
                string imagePath = System.IO.Path.Combine(imagesFolder, item.Picture);

                if (!System.IO.File.Exists(imagePath)) item.Picture = defaultImagePath;

                else item.Picture = imagePath;

                itemColl.Add(item);

            }
            TovarLB.ItemsSource = itemColl;
            CountTextBlock.Text = $"Товаров: {itemColl.Count}";

        }
        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                string username = loginWindow.LoggedInUsername;
                string role = loginWindow.LoggedInRole;
                UpdateAuthUI(username, role);
            }
        }


        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginTextBlock.Visibility = Visibility.Collapsed;
            RoleTextBlock.Visibility = Visibility.Collapsed;

            AuthButton.Visibility = Visibility.Visible;
            RegisterButton.Visibility = Visibility.Visible;
            LogoutButton.Visibility = Visibility.Collapsed;

            MessageBox.Show("Вы вышли из аккаунта.");
        }



        public void UpdateAuthUI(string username, string role)
        {
            LoginTextBlock.Text = $"Логин: {username}";
            RoleTextBlock.Text = $"Роль: {role}";

            LoginTextBlock.Visibility = Visibility.Visible;
            RoleTextBlock.Visibility = Visibility.Visible;

            AuthButton.Visibility = Visibility.Collapsed;
            RegisterButton.Visibility = Visibility.Collapsed;
            LogoutButton.Visibility = Visibility.Visible;
        }


        private void Filter_Changed(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string search = SearchTB?.Text?.ToLower() ?? "";
            string discountFilter = (DiscountFilterCB.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Все скидки";


            var filtered = allItems.Where(item =>
            {
                if (!string.IsNullOrWhiteSpace(search) &&
                    !item.Naimenovanie.ToLower().Contains(search))
                    return false;

                double discount = item.Deistvyushay_sale;
                return discountFilter switch
                {
                    "0% - 4%" => discount >= 0 && discount <= 4,
                    "5% - 7%" => discount >= 5 && discount <= 7,
                    _ => true
                };
            }).ToList();

            itemColl.Clear();
            foreach (var item in filtered)
                itemColl.Add(item);
        }

    }

}

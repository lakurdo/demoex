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
        ObservableCollection<Tovar> itemColl { get; set; }
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
            MessageBox.Show($"Загружено товаров: {items}");

            foreach (var item in items)
            {
                string imagePath = System.IO.Path.Combine(imagesFolder, item.Picture);

                if (!System.IO.File.Exists(imagePath)) item.Picture = defaultImagePath;

                else item.Picture = imagePath;

                itemColl.Add(item);
                    
            }
            TovarLB.ItemsSource = itemColl;
            MessageBox.Show($"Загружено товаров: {itemColl.Count}");

        }

    }
}

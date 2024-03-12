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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.datas;
using Microsoft.Win32;
using System.IO;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        toy toy;
        public AddEditPage(toy _toy)
        {
            InitializeComponent();
            TypeCB.ItemsSource = App.db.Type.ToList();
            TypeCB.DisplayMemberPath = "Name";
            toy = _toy;
            DataContext = toy;


        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            toy.TypeId = (TypeCB.SelectedItem as datas.Type).Id;
            if(toy.Id == 0)
                App.db.toy.Add(toy);

            App.db.SaveChanges();
            MessageBox.Show("Успешно!");
            NavigationService.Navigate(new ToyListPage());
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jepg|*.jepg|*.jpg|*.jpg"
            };
            if(openFileDialog.ShowDialog() != null)
            {
                toy.MainImage = File.ReadAllBytes(openFileDialog.FileName);
                ToyImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }

        }
    }
}

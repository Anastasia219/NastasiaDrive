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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizatePage.xaml
    /// </summary>
    public partial class AutorizatePage : Page
    {
        public AutorizatePage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void EntBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(LogTB.Text) || string.IsNullOrWhiteSpace(PasPB.Password))
                {
                    error.AppendLine("Заполните поля!");
                }
                App.authorizateUser = App.db.user.FirstOrDefault(x => x.Login == LogTB.Text && x.Password == PasPB.Password);
                if (App.authorizateUser == null) 
                    error.AppendLine("Пользователя не существует");
                if (error.Length > 0) 
                    MessageBox.Show(error.ToString());
                else 
                    NavigationService.Navigate(new ToyListPage());

            }
            catch
            {
                MessageBox.Show("Ошибка");
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            try
            {
                if (string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(LogTB.Text) || string.IsNullOrWhiteSpace(PasPB.Password) || string.IsNullOrWhiteSpace(Pas2PB.Password))
                {

                    error.AppendLine("Заполни меня");
                }
                if (PasPB.Password!=Pas2PB.Password)
                {
                    error.AppendLine("Пароли не совпадают!");

                }

                if (App.db.user.FirstOrDefault(x => x.Login == LogTB.Text) != null) error.AppendLine("Логин занят ");
               
                if (error.Length > 0)
                    MessageBox.Show(error.ToString());
                else 
                {
                    App.db.user.Add(new user
                    {
                        Name = NameTB.Text,
                        Login= LogTB.Text,
                        Password = PasPB.Password,
                        Roleid = 1,
                    });
                     App.db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно"); 
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }

        }
    }
}

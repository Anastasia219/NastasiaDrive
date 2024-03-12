using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для ToyListPage.xaml
    /// </summary>
    public partial class ToyListPage : Page
    {

        public ToyListPage()
        {
            InitializeComponent();
            ToyList.ItemsSource = App.db.toy.ToList();
            var typeFilter =App.db.Type.ToList();
            TypeFilterCb.DisplayMemberPath = "Name";
            typeFilter.Insert(0, new datas.Type() { Id = 0, Name ="Все" });
            TypeFilterCb.ItemsSource = typeFilter;
            if (App.authorizateUser.Roleid == 1 )
            {
                AddBtn.Visibility = Visibility.Hidden;
                CreateBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
            
        }
        private void Refresh()
            {

            IEnumerable<toy> filterToy = App.db.toy;
            if(SearchTb.Text.Length>0)
                filterToy = filterToy.Where(x=> x.Name.StartsWith(SearchTb.Text));
         

            var selType = TypeFilterCb.SelectedItem as datas.Type;
            if (selType!=null)
            {
                if (TypeFilterCb.SelectedIndex > 0)
                    filterToy = filterToy.Where(x => x.TypeId == selType.Id);
                //Main
            }

            ToyList.ItemsSource = filterToy.ToList();

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh(); 
        }

        private void TypeFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage(new toy()));


        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
           toy selectToy= ToyList.SelectedItem as toy;
            if (selectToy != null)
                NavigationService.Navigate(new AddEditPage(selectToy));
            else
                MessageBox.Show("Ничего не выбрано из списка!");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

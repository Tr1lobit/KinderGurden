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
using AfonichevKinderGarden.Model;

namespace AfonichevKinderGarden.PageMain
{
    /// <summary>
    /// Interaction logic for PageAddActivity.xaml
    /// </summary>
    public partial class PageAddActivity : Page
    {
        public PageAddActivity()
        {
            InitializeComponent();
            ActivityTypeCmb.ItemsSource = App.GetContext().Direction.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string addCheck = "";

            if (string.IsNullOrWhiteSpace(ActivityTb.Text))
            {
                addCheck += "Введите название мероприятия\n";
            }
            if (string.IsNullOrWhiteSpace(ActivityTypeCmb.Text))
            {
                addCheck += "Выберите тип мероприятия\n";
            }

            if (addCheck != "")
            {
                MessageBox.Show(addCheck);
                addCheck = "";
                return;
            }

            Activity activity = new Activity()
            {
                Name = ActivityTb.Text,
                Direction = ActivityTypeCmb.SelectedItem as Direction
            };

            App.GetContext().Activity.Add(activity);
            App.GetContext().SaveChanges();
            MessageBox.Show("Мероприятие добавлено!");

            NavigationService.Navigate(new PageBody());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageBody());
        }
    }
}
